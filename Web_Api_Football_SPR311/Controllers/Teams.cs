using AutoMapper;
using Data;
using Data.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Football_SPR311.Dtos;

namespace Web_Api_Football_SPR311.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly FootballDbContext ctx;
        private readonly IMapper mapper;
        private readonly IValidator<CreateTeamModel> _validator;

        public TeamsController(FootballDbContext ctx, IMapper mapper, IValidator<CreateTeamModel> validator)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            _validator = validator;
        }

        [HttpGet("/all-teams")] // domain/all-teams
        [HttpGet("all")]        // domain/api/teams/all
        public IActionResult GetAll()
        {
            var items = ctx.FootballTeams.ToList();
            return Ok(mapper.Map<List<TeamModel>>(items));
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.FootballTeams.Find(id);
            if (item == null) return NotFound(); // 404
            
            return Ok(mapper.Map<TeamModel>(item)); // 200
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamModel model)
        {
            // var entity = new Team()
            // {
            //     Logo = model.Logo,
            //     Name = model.Name,
            //     Country = model.Country
            // };
            
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid) return BadRequest(result.Errors);
            
            ctx.FootballTeams.Add(mapper.Map<Team>(model));
            ctx.SaveChanges();
            
            return Created(); // 201
        }
        
        [HttpPut]
        public IActionResult Edit(UpdateTeamModel model)
        {
            // var entity = new Team()
            // {
            //     Id = model.Id,
            //     Logo = model.Logo,
            //     Name = model.Name,
            //     Country = model.Country
            // };
            
            ctx.FootballTeams.Update(mapper.Map<Team>(model));
            ctx.SaveChanges();
            
            return Ok(); // 200
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = ctx.FootballTeams.Find(id);
            if (item == null) return NotFound();
            
            ctx.FootballTeams.Remove(item);
            ctx.SaveChanges();

            return NoContent(); // 204
        }
    }
}
