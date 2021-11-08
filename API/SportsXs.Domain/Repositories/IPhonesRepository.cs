using System;
using System.Threading.Tasks;
using SportsXs.Domain.Entities;

namespace SportsXs.Domain.Repositories
{
    public interface IPhonesRepository
    {
        Task Add(Phones phones);
    }
}