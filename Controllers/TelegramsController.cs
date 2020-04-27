using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telemetrics.Models;

namespace Telemetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramsController : ControllerBase
    {
        private readonly TelegramContext _context;

        public TelegramsController(TelegramContext context)
        {
            _context = context;
        }

        // GET: api/Telegrams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telegram>>> GetTelegrams()
        {
            //тестовый вызов для проверки моего API-клиента ClientSend.cs в этом проекте
            //ClientSend.SendTelegram(11.1F, 12.1F, 13.1F, 14.1F, 15.1F, "ClientSend_OK");

            return await _context.Telegrams.ToListAsync();
        }

        // GET: api/Telegrams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telegram>> GetTelegram(long id)
        {
            var telegram = await _context.Telegrams.FindAsync(id);

            if (telegram == null)
            {
                return NotFound();
            }

            return telegram;
        }

        // PUT: api/Telegrams/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelegram(long id, Telegram telegram)
        {
            if (id != telegram.Id)
            {
                return BadRequest();
            }

            _context.Entry(telegram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelegramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Telegrams
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Telegram>> PostTelegram(Telegram telegram)
        {
            _context.Telegrams.Add(telegram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTelegram), new { id = telegram.Id }, telegram);
        }

        // DELETE: api/Telegrams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Telegram>> DeleteTelegram(long id)
        {
            var telegram = await _context.Telegrams.FindAsync(id);
            if (telegram == null)
            {
                return NotFound();
            }

            _context.Telegrams.Remove(telegram);
            await _context.SaveChangesAsync();

            return telegram;
        }

        private bool TelegramExists(long id)
        {
            return _context.Telegrams.Any(e => e.Id == id);
        }
    }
}
