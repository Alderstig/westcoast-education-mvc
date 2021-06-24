using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using App.Interfaces;
using App.Models;
using App.ViewModels;
using Microsoft.Extensions.Configuration;

namespace App.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _options;

        public ParticipantService(IConfiguration config, HttpClient http)
        {
            _baseUrl = config.GetSection("api:baseUrl").Value + config.GetSection("api:participantsBaseUrl").Value;
            _http = http;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> AddParticipant(ParticipantModel model)
        {
            try
            {
                var data = JsonSerializer.Serialize(model);

                var response = await _http.PostAsync(_baseUrl, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParticipantModel> GetParticipantAsync(int id)
        {
            var response = await _http.GetAsync($"{_baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ParticipantModel>(data, _options);

                return result;
            }
            else
            {
                throw new Exception("Det gick fel");
            }
        }

        public async Task<ParticipantModel> GetParticipantAsync(string email)
        {
            var response = await _http.GetAsync($"{_baseUrl}find/{email}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ParticipantModel>(data, _options);

                return result;
            }
            else
            {
                throw new Exception("Det gick fel");
            }
        }

        public async Task<List<ParticipantModel>> GetParticipantsAsync()
        {
            var response = await _http.GetAsync($"{_baseUrl}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ParticipantModel>>(data, _options);

                return result;
            }
            else
            {
                throw new Exception("Det gick fel");
            }
        }

        public async Task<bool> UpdateParticipant(int id, UpdateParticipantViewModel model)
        {
            try
            {
                var url = $"{_baseUrl}/{id}";
                var data = JsonSerializer.Serialize(model);
                var response = await _http.PutAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}