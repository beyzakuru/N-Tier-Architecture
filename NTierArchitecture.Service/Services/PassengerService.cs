using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.API.Abstraction;
using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.DTOs.Authentication;
using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Repositories;
using NTierArchitecture.Core.Services;
using NTierArchitecture.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Services
{

    public class PassengerService : Service<Passenger>, IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IGenericRepository<Passenger> _repository;


        public PassengerService(IGenericRepository<Passenger> repository, IUnitOfWork unitOfWork, IPassengerRepository passengerRepository, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager
            ) : base(repository, unitOfWork)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        
        // Bu metodun amacı verilen passwordü hashleyerek veritabanına katmetmesidir.
        public string GeneratePasswordHash(string firstName, string password)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrEmpty(password))
            {  
                throw new ArgumentNullException(nameof(password)); 
            }

            byte[] passengerBytes = Encoding.UTF8.GetBytes(firstName);
            string passsengerByteString = Convert.ToBase64String(passengerBytes);
            string smallByteString = $"{passsengerByteString.Take(2)}.{passsengerByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);
        }

        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }
            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public PassengerDto FindPassenger(string firstName, string password)
        {
            string passHashed = GeneratePasswordHash(firstName, password);

            var passenger = _repository.Where(x => x.FirstName == firstName && x.Password == passHashed).FirstOrDefault();
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return passengerDto;
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            PassengerDto passenger = FindPassenger(request.FirstName, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.FirstName, request.Password);
            responseDto.Passenger= passenger;
            return responseDto;
        }

        public Passenger SignUp(AuthRequestDto authDto)
        {
            // passwordün hashli olarak gönderilemesini sağlayan metot yazılmalı. passengerService'e
            #region Password'ün hashli halini veritabanına göndermek için  güncelleme yap.
            var passwordHash = GeneratePasswordHash(authDto.FirstName, authDto.Password);
            #endregion

            var passenger = AddAsync(new Passenger
            {
                EMail = authDto.Email,
                Password = passwordHash,
                FirstName = authDto.FirstName,
                JourneyId = 1
            });
            return passenger.Result;
        }
    }
}
