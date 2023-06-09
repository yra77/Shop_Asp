﻿

using Shop_Asp.Models;

namespace Shop_Asp.Domain.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Login GetLogin(Login user);
        Task<int> AddUpdateLogin(Login user);
        Task<Login?> GetUserAccount(string email);
        Task<int> DeleteLogin(string email);
    }
}
