using DataAccess.Context;
using Entity.Concrete;
using LMS_API.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LMS_API.DataAccess.Concrete
{
    public class EfUserDal : IUserDal
    {
        private readonly AppDbContext _context;

        public EfUserDal(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User Get(System.Func<User, bool> predicate)
        {
            return _context.Users.FirstOrDefault(predicate);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
