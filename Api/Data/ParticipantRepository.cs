using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DataContext _context;

        public ParticipantRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
        }

        public async Task<Participant> GetParticipantAsync(string email)
        {
            var participant = await _context.Participants.SingleOrDefaultAsync(c => c.Email == email);

            return participant;
        }

        public async Task<Participant> GetParticipantAsync(int id)
        {
            return await _context.Participants.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Participant>> GetParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<bool> SavAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Participant participant)
        {
            _context.Participants.Update(participant);
        }
    }
}