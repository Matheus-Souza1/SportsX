using SportsXs.Domain.Enum;
using System;
using System.Collections.Generic;

namespace SportsXs.Domain.Entities
{
    public class Client : BaseEntity
    {
        public Client()
        {
        }

        public Client(string name, string corporateName, string document, string email, string cep, Classification classification, TypeClient typeClient, List<Phones> phones)
        {
            Name = name;
            CorporateName = corporateName;
            Document = document;
            Email = email;
            Cep = cep;
            Classification = classification;
            TypeClient = typeClient;
            Phones = phones;
        }

        public string Name { get; private set; }
        public string CorporateName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Cep { get; private set; }
        public Classification Classification { get; private set; }
        public TypeClient TypeClient { get; private set; }
        public List<Phones> Phones { get; set; }

        public void Update( string name, string corporateName, string document, string email, string cep, Classification classification, TypeClient typeClient, List<Phones> phones)
        {
            Name = name;
            CorporateName = corporateName;
            Document = document;
            Email = email;
            Cep = cep;
            Classification = classification;
            TypeClient = typeClient;
            Phones = phones;
        }

        public void UpdatePhones(List<Phones> phones)
        {
            Phones = phones;
        }
    }
}
