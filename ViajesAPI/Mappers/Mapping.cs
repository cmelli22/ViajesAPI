using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
