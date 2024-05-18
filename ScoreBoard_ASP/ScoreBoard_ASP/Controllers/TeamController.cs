using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreBoard_ASP.Data;
using ScoreBoard_ASP.Entities;

namespace ScoreBoard_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            var teams = await _context.Teams.ToListAsync();

            return Ok(teams);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team is null)
            {
                return NotFound($"Team with id {id} doesnot exist.");
            }

            return Ok(team);
        }

        [HttpPost]

        public async Task<ActionResult<Team>> AddTeam(Team team)
        {
            var dbTeam = await _context.Teams.FindAsync(team.Id);

            if (dbTeam is not null)
            {
                return BadRequest($"Team with id {team.Id} already exist.");
            }

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();


            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpPut]

        public async Task<ActionResult<Team>> UpdateTeam(Team updatedTeam)
        {
            var dbTeam = await _context.Teams.FindAsync(updatedTeam.Id);

            if (dbTeam is null)
            {
                return NotFound($"Team with id {updatedTeam.Id} doesnot exist.");
            }

            dbTeam.Score = updatedTeam.Score;
            dbTeam.TotalGamesPlayed = updatedTeam.TotalGamesPlayed;
            dbTeam.TeamName = updatedTeam.TeamName;


            await _context.SaveChangesAsync();
            return Ok(updatedTeam);
        }



        [HttpDelete]

        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var dbTeam = await _context.Teams.FindAsync(id);

            if (dbTeam is null)
            {
                return NotFound($"Team with id {id} doesnot exist.");
            }

            _context.Teams.Remove(dbTeam);
            await _context.SaveChangesAsync();
            return Ok("Deleted Successfuly");
        }


    }
}
