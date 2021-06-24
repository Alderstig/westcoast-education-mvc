using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;

namespace App.Interfaces
{
    public interface IParticipantService
    {
        Task<List<ParticipantModel>> GetParticipantsAsync();
        Task<ParticipantModel> GetParticipantAsync(int id);
        Task<ParticipantModel> GetParticipantAsync(string email);
        Task<bool> AddParticipant(ParticipantModel model);
        Task<bool> UpdateParticipant(int id, UpdateParticipantViewModel model);
    }
}