
using AutoMapper;
using SportsXs.API.InputModel;
using SportsXs.API.ViewModels;
using SportsXs.Domain.Entities;
using System;

namespace SportsXs.API.Profiles
{
    public class ClientProfile : Profile
    {
        [Obsolete]
        public ClientProfile()
        {

            CreateMap<Client, AddClientInputModel>().ReverseMap();
            CreateMap<Client, UpdateClientInputModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();

            CreateMap<Phones, PhonesViewModel>().ReverseMap();
        }
            
    }
}