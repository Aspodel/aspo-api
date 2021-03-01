using Aspo.Api.DataObjects.Create;
using Aspo.Core.Entities;
using AutoMapper;

namespace Aspo.Api.DataObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore());
            CreateMap<UserDTO, ApplicationUser>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Conversations, opt => opt.Ignore())
                .ForMember(x => x.Messages, opt => opt.Ignore());


            CreateMap<Conversation, ConversationDTO>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore());
            CreateMap<ConversationDTO, Conversation>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Creator, opt => opt.Ignore());

            CreateMap<Conversation, CreateConversationDTO>();
            CreateMap<CreateConversationDTO, Conversation>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Creator, opt => opt.Ignore())
                .ForMember(x => x.Messages, opt => opt.Ignore());


            CreateMap<Message, MessageDTO>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore());
            CreateMap<MessageDTO, Message>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Sender, opt => opt.Ignore())
                .ForMember(x => x.Conversation, opt => opt.Ignore());


            CreateMap<Participant, ParticipantDTO>()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore());
            CreateMap<ParticipantDTO, Participant>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore())
                .ForMember(x => x.Conversation, opt => opt.Ignore());
        }
    }
}
