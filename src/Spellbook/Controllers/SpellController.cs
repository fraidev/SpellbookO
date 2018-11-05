using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Spellbook.Domains.Read.Repositories;
using Spellbook.Domains.Write.Commands;
using Spellbook.Domains.Write.Repositories;
using Spellbook.Domains.Write.States;
using Spellbook.Infrastructure.Persistence;

namespace Spellbook.Controllers
{
    [Route("api/[controller]")]
    public class SpellController: Controller
    {
        private readonly ISpellRepository _spellRepository;
        private readonly ISpellReadRepository _spellReadRepository;

        public SpellController(ISpellRepository spellRepository, 
            ISpellReadRepository spellReadRepository)
        {
            _spellRepository = spellRepository;
            _spellReadRepository = spellReadRepository;
        }
        
        [HttpPost]
        [Route("createSpell")]
        [Authorize]
        public IActionResult CreateSpell([FromBody] CreateSpell cmd)
        {
            _spellRepository.Add(new SpellState()
            {
                Id = cmd.Id,
                Text = cmd.Text,
                UserId =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value
            });
            return Ok();
        }
        
        [HttpGet]
        [Route("getSpells")]
        [Authorize]
        public IActionResult GetSpells()
        {
            return Ok(_spellReadRepository.GetbyUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value));
        }
    }
}