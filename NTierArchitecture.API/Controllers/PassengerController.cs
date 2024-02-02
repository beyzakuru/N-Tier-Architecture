using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.API.Abstraction;
using NTierArchitecture.API.Concrete;
using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.DTOs.Authentication;
using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Services;
using NTierArchitecture.Service.Services;

namespace NTierArchitecture.API.Controllers
{
    public class PassengerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPassengerService _passengerService;

        public PassengerController(IMapper mapper, IPassengerService passengerService)
        {
            _mapper = mapper;
            _passengerService = passengerService;
        }

        // Get api/passenger/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var passengers = await _passengerService.GetAllAsync();
            var passengersDto = _mapper.Map<List<PassengerDto>>(passengers.ToList());
            return CreateActionResult(GlobalResultDto<List<PassengerDto>>.Success(200, passengersDto));
        }

        // Get api/passenger/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var passenger = await _passengerService.GetById(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return CreateActionResult(GlobalResultDto<PassengerDto>.Success(200, passengerDto));
        }

        //[HttpPost]
        //public async Task<IActionResult> Save(PassengerDto passengerDto)
        //{
        //    var passenger = await _passengerService.AddAsync(_mapper.Map<Passenger>(passengerDto));
        //    var passengerDtos = _mapper.Map<JourneyDto>(passenger);
        //    return CreateActionResult(GlobalResultDto<JourneyDto>.Success(201, passengerDtos));
        //}

        [HttpPut]
        public async Task<IActionResult> Update(PassengerDto passengerDto)
        {
            await _passengerService.UpdateAsync(_mapper.Map<Passenger>(passengerDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var passenger = await _passengerService.GetById(id);
            await _passengerService.RemoveAsync(passenger);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        // Kayıt ol
        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(AuthRequestDto authDto)
        {
            var passenger = _passengerService.SignUp(authDto);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return CreateActionResult(GlobalResultDto<PassengerDto>.Success(201, passengerDto));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            var result = _passengerService.Login(authDto);
            if (result.Passenger != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }
    }
}
