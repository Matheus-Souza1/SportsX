using SportsXs.API.ViewModels;
using SportsXs.Domain.Entities;
using SportsXs.Domain.Enum;
using System.Collections.Generic;

namespace SportsXs.API.InputModel
{
    public class AddClientInputModel
    {
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
