using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/participants")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantRepository _repo;

        public ParticipantsController(IParticipantRepository repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<IActionResult> GetParticipants()
        {
            var result = await _repo.GetParticipantsAsync();

            return Ok(result);
        }

        [HttpGet("find/{email}")]
        public async Task<IActionResult> GetParticipantByEmail(string email)
        {
            try
            {
                var participant = await _repo.GetParticipantAsync(email);

                if (participant == null) return NotFound();

                return Ok(participant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddParticipant(Participant participant)
        {
            try
            {
                await _repo.AddAsync(participant);

                if (await _repo.SavAllChangesAsync()) return StatusCode(201);

                return StatusCode(500, "Kunde ej lägga till deltagare");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            try
            {
                var participant = await _repo.GetParticipantAsync(id);

                if (participant == null) return NotFound();

                return Ok(participant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Participant participantModel)
        {
            var participant = await _repo.GetParticipantAsync(id);
            participant.FirstName = participantModel.FirstName;
            participant.LastName = participantModel.LastName;
            participant.Email = participantModel.Email;
            participant.MobileNum = participantModel.MobileNum;
            participant.Adress = participantModel.Adress;

            _repo.Update(participant);
            var result = await _repo.SavAllChangesAsync();

            return NoContent();
        }
    }
}