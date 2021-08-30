using System;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.BL
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(User user);
    }
}