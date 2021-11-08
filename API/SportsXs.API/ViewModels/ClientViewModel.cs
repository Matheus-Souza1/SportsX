using System;
using System.Collections.Generic;
using SportsXs.Domain.Entities;
using SportsXs.Domain.Enum;

namespace SportsXs.API.ViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel(Guid id, string name, string corporateName, string document, string email, string cep, TypeClient typeClient, Classification classification, List<PhonesViewModel> phones)
        {
            Id = id;
            Name = name;
            CorporateName = corporateName;
            Document = document;
            Email = email;
            Cep = cep;
            TypeClient = typeClient;
            Classification = classification;
            Phones = phones;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public TypeClient TypeClient { get; set; }
        public Classification Classification { get; set; }
        public List<PhonesViewModel> Phones { get; set; }
    }
}