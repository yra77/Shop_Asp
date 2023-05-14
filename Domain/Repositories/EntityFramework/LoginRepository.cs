

using Shop_Asp.Domain.Repositories.Interfaces;
using Shop_Asp.Domain.Helpers;
using Shop_Asp.Models;
using Microsoft.EntityFrameworkCore;


namespace Shop_Asp.Domain.Repositories.EntityFramework
{
    public class LoginRepository : ILoginRepository
    {


        private readonly ApplicationContext _context;


        public LoginRepository(ApplicationContext context)
        {
            _context = context;
        }


        public Login GetLogin(Login user)
        {
            return _context.Logins.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
        }

        public async Task<int> AddUpdateLogin(Login user) 
        {

           var result = _context.Logins.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (result == null)
            {
                var countUsers =  _context.Logins.AsNoTracking().Select(x=>x.Id).Max();//found max id and ++
                user.Id = ++countUsers;
                user.Address = "";
                user.ImageAccount = "Images/editphoto.png";
               // _context.Logins.Add(user);
                _context.Entry(user).State = EntityState.Added;
            }
            else
            {
                _context.Logins.Update(user);//Entry(item).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Login?> GetUserAccount(string email)
        {
            return await _context.Logins.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<int> UpdateUserAccount(string email, 
                                                 string phone,
                                                 string name, 
                                                 string address, 
                                                 int cartstatus, 
                                                 string favoriteList,
                                                 string pathPhoto)
        {

            var result = _context.Logins.FirstOrDefault(x => x.Email == email);

           
               // _context.Logins.Update(user);
          
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteLogin(string email) 
        {
            var item = await _context.Logins.FirstOrDefaultAsync(x => x.Email == email);
            _context.Logins.Remove(item);
            return await _context.SaveChangesAsync();
        }

    }
}
