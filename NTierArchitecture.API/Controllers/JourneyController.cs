using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NTierArchitecture.Core.DTOs;
using NTierArchitecture.Core.Models;
using NTierArchitecture.Core.Services;
using NTierArchitecture.Service.Services;

namespace NTierArchitecture.API.Controllers
{
    public class JourneyController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IJourneyService _journeyService;

        public JourneyController(IMapper mapper, IJourneyService journeyService)
        {
            _mapper = mapper;
            _journeyService = journeyService;
        }

        // Get api/journey/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var journeys = await _journeyService.GetAllAsync();
            var journeysDto = _mapper.Map<List<JourneyDto>>(journeys.ToList());
            return CreateActionResult(GlobalResultDto<List<JourneyDto>>.Success(200, journeysDto));
        }

        // Get api/journey/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var journey = await _journeyService.GetById(id);
            var journeyDto = _mapper.Map<JourneyDto>(journey);
            return CreateActionResult(GlobalResultDto<JourneyDto>.Success(200, journeyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(JourneyDto journeyDto)
        {
            var journey = await _journeyService.AddAsync(_mapper.Map<Journey>(journeyDto));
            var journeyDtos = _mapper.Map<JourneyDto>(journey);
            return CreateActionResult(GlobalResultDto<JourneyDto>.Success(201, journeyDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(JourneyDto journeyDto)
        {
            await _journeyService.UpdateAsync(_mapper.Map<Journey>(journeyDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var journey = await _journeyService.GetById(id);
            await _journeyService.RemoveAsync(journey);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
