using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Models;

namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminder")]
    public class RemindersController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<RemindersController> _logger;

        private readonly IReminderStorage _reminderStorage;

        public RemindersController(
            ILogger<RemindersController> logger,
            IReminderStorage reminderStorage)
        {
            _logger = logger;
            _reminderStorage = reminderStorage;
        }

        [HttpGet]
        public IActionResult GetReminders(
            [FromQuery(Name = "count")] int count = 0,
            [FromQuery(Name = "startPosition")]int startPosition = 0)
        {
            List<ReminderItem> reminders = _reminderStorage.Get(count, startPosition);
            List<ReminderItemGetModel> reminderItemGetModels = reminders.Select(x => new ReminderItemGetModel(x)).ToList();
            return Ok(reminderItemGetModels);
        }
        [HttpGet("{id}")]
        public IActionResult GetReminder(Guid id)
        {
            var reminder = _reminderStorage.Get(id);
            if (reminder != null)
            {

                return Ok(new ReminderItemGetModel(reminder));
            }
            else
                return NotFound("404 Not Found");
        }
        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminderItemModel)
        {
            if (reminderItemModel == null)
            {
                return BadRequest();
            }
            var reminderItem = reminderItemModel.ToReminderItem();
            _reminderStorage.Add(reminderItem);

            var reminderModel = new ReminderItemGetModel(reminderItem);

            return CreatedAtAction("GetReminder", new { id = reminderModel.Id }, reminderModel);
        }
    }
}
