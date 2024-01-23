using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Services;

namespace NTierArchitecture.API.Controllers
{
    public class PassportController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPassportService _passportService;

        public PassportController(IMapper mapper, IPassportService passportService)
        {
            _mapper = mapper;
            _passportService = passportService;
        }

        // Get api/passenger/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var passports = await _passportService.GetAllAsync();
            var passportsDto = _mapper.Map<List<PassportDto>>(passports.ToList());
            return CreateActionResult(GlobalResultDto<List<PassportDto>>.Success(200, passportsDto));
        }

        // Get api/passenger/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var passport = await _passportService.GetById(id);
            var passportDto = _mapper.Map<PassportDto>(passport);
            return CreateActionResult(GlobalResultDto<PassportDto>.Success(200, passportDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PassportDto passportDto)
        {
            var passport = await _passportService.AddAsync(_mapper.Map<Passport>(passportDto));
            var passportDtos = _mapper.Map<PassportDto>(passport);
            return CreateActionResult(GlobalResultDto<PassportDto>.Success(201, passportDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PassportDto passportDto)
        {
            await _passportService.UpdateAsync(_mapper.Map<Passport>(passportDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var passport = await _passportService.GetById(id);
            await _passportService.RemoveAsync(passport);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
