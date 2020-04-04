using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class RemindersController : ControllerBase
    {
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
            [FromQuery(Name = "status")] ReminderItemStatus status,
            [FromQuery(Name = "count")] int count = 0,
            [FromQuery(Name = "startPostion")] int startPostion = 0)
        {
            List<ReminderItem> reminderItems = new List<ReminderItem>();
            if (status == ReminderItemStatus.Undefined)
            {
                reminderItems = _reminderStorage.Get(count, startPostion);
            }
            else
            {
                reminderItems = _reminderStorage.Get(status, count, startPostion);
            }

            List<ReminderItemGetModel> reminderItemGetModels =
                reminderItems
                    .Select(x => new ReminderItemGetModel(x))
                    .ToList();

            return Ok(reminderItemGetModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetReminder(Guid id)
        {
            var reminderItem = _reminderStorage.Get(id);
            if (reminderItem == null)
            {
                return NotFound();
            }

            return Ok(new ReminderItemGetModel(reminderItem));
        }

        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderItemCreateModel reminderItemCreateModel)
        {
            if (reminderItemCreateModel == null)
            {
                return BadRequest();
            }

            var reminderItemRestricted = reminderItemCreateModel.ToReminderItemRestricted();
            Guid id = _reminderStorage.Add(reminderItemRestricted);

            var reminderItemGetModel = new ReminderItemGetModel(id, reminderItemRestricted);

            return CreatedAtAction(
                "GetReminder",
                new { id = id },
                reminderItemGetModel);
        }

        [HttpPut]
        public IActionResult EditReminder([FromQuery(Name = "id")] Guid id, [FromQuery(Name = "status")]ReminderItemStatus status)
        {
            _reminderStorage.UpdateStatus(id, status);
            return Ok("Status changed");
        }
        [HttpDelete]
        public IActionResult RemoveReminder([FromQuery(Name = "id")]Guid id)
        {
            if (_reminderStorage.Remove(id))
                return Ok();
            else
                return NotFound();
        }
    }
}