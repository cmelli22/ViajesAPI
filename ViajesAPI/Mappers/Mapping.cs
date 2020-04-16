using AutoMapper;
using ViajesAPI.Models.Entities;
using ViajesAPI.ViewModels;
using ViajesAPI.ViewModels.BodyModels;

namespace ViajesAPI.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Message, MessageViewModel>().ReverseMap();
            CreateMap<BodyMessage, Message>().ReverseMap();
        }

    }
}
