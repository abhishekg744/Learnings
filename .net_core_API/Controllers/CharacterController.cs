using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _net_core_API.Models;
using _net_core_API.Dtos.Character;

namespace _net_core_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> Get() {
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
        
    }
}