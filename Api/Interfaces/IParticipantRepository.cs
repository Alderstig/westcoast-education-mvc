using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface IParticipantRepository
    {
        Task<Participant> GetParticipantAsync(string email);
        Task<Participant> GetParticipantAsync(int id);
        Task<IEnumerable<Participant>> GetParticipantsAsync();
        Task AddAsync(Participant participant);
        void Update(Participant participant);
        Task<bool> SavAllChangesAsync();
    }
}