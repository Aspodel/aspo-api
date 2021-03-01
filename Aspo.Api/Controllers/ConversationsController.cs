using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspo.Core.Database;
using Aspo.Core.Entities;
using Aspo.Contracts;
using AutoMapper;
using Aspo.Api.DataObjects;
using Microsoft.AspNetCore.Identity;

namespace Aspo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IParticipantRepository _participantRepository;

        public ConversationsController(IConversationRepository conversationRepository, IMapper mapper, UserManager<ApplicationUser> userManager,IParticipantRepository participantRepository)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _participantRepository = participantRepository;
        }

        // GET: api/Conversations
        [HttpGet]
        public async Task<IActionResult> GetAll(string userId)
        {
            var conversations = await _conversationRepository.FindAll(userId).ToListAsync();
            return Ok(conversations);
        }

        // GET: api/Conversations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var conversation = await _conversationRepository.FindByIdAsync(id);

            if (conversation == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ConversationDTO>(conversation));
        }

        // PUT: api/Conversations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ConversationDTO dTO)
        {
            //_context.Entry(conversation).State = EntityState.Modified;

            //try
            //{
            //    await _conversationRepository.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ConversationExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Conversations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conversation>> Create(ConversationDTO dTO)
        {
            var creator = await _userManager.FindByIdAsync(dTO.CreatorId);
            var participant = new Participant()
            {
                User = creator
            };
            //dTO.Participants.Add(participant);
            var conversation = _mapper.Map<Conversation>(dTO);
            conversation.Creator = creator;

            _conversationRepository.Add(conversation);

            await _conversationRepository.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = conversation.Id }, conversation);
        }

        // DELETE: api/Conversations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var conversation = await _conversationRepository.FindByIdAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }

            _conversationRepository.Delete(conversation);
            await _conversationRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
