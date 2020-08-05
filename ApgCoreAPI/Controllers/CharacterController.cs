using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApgCoreAPI.Models;
using ApgCoreAPI.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using RabbitMQEventBus.Event;
using AutoMapper;
using RabbitMQEventBus.Producer;
using RabbitMQEventBus.Common;

namespace ApgCoreAPI.Controllers
{
    [Authorize]
    [ApiController]    
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ProducerEventBus _eventBus;

        public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger, IMapper mapper, ProducerEventBus eventBus)
        {
            _logger = logger;
            _mapper = mapper;
            _eventBus = eventBus;
            _characterService = characterService;
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> Get() {
            // 1 of the advantage of ControllerBase - access claims directly through User objectt
            int userId = int.Parse(User.Claims.FirstOrDefault(claims=>claims.Type == ClaimTypes.NameIdentifier).Value);
             _logger.LogInformation("Log message in Character get all API");
            _logger.LogCritical("Log message in Character get all API");
            return Ok(await _characterService.GetAllCharacters());
        }

        [Route("{id}")]
        public async Task<IActionResult> GetSingal(int id) {
            return Ok(await _characterService.GetCharacter(id));
        }

        [HttpPost]
         public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter) {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
         public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter) {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updateCharacter);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteCharacter(int id) {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if(response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Publish")]
        public async Task<IActionResult> Publish([FromBody] PublishEvent data)
        {
            var eventMessage = _mapper.Map<TankMonitorProducerEvent>(data);
            eventMessage.RequestId = Guid.NewGuid();
            try
            {
                _eventBus.PublishTankMonitor(EventBusConstants.TankMonitorQueue, eventMessage);
            }
            catch (Exception)
            {

                throw;
            }
            
            return Accepted();
        }
    }
}