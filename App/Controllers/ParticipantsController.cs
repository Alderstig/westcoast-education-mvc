using System.Threading.Tasks;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using App.Interfaces;
using System;
using App.Models;

namespace App.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipantService _service;

        public ParticipantsController(IParticipantService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetParticipantsAsync();

            return View("Index", result);
        }

        [HttpGet]
        public async Task<IActionResult> Filter(string email)
        {
            //Denna funktion är ej implementerad

            var result = await _service.GetParticipantAsync(email);

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult CreateParticipant()
        {
            return View("CreateParticipant");
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(RegisterParticipantViewModel data)
        {
            if (!ModelState.IsValid) return View("CreateParticipant");

            var participant = new ParticipantModel
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                MobileNum = data.MobileNum,
                Adress = data.Adress
            };

            try
            {
                if (await _service.AddParticipant(participant)) return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditParticipantViewmodel data)
        {
            try
            {
                var participantModel = new UpdateParticipantViewModel
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    MobileNum = data.MobileNum,
                    Adress = data.Adress
                };
                if (await _service.UpdateParticipant(data.Id, participantModel)) return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var participant = await _service.GetParticipantAsync(id);

            var model = new EditParticipantViewmodel
            {
                FirstName = participant.FirstName,
                LastName = participant.LastName,
                Email = participant.Email,
                MobileNum = participant.MobileNum,
                Adress = participant.Adress
            };

            return View("Edit", model);
        }
    }
}