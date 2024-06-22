using PFMA.Data.Models;
using PFMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMA.Service
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User? Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
            return user;
        }

        public void Register(string fullName, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                CreatedAt = DateTime.UtcNow,
                Status = Common.UserStatus.Active
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
