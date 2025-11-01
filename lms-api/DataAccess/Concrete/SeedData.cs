using Entity.Concrete;
using LMS_API.DataAccess.Concrete.EntityFramework;

namespace LMS_API.DataAccess.Concrete
{

    public static class SeedData
    {
        public static void Initialize(LMSContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
            {
                new User { FullName = "Admin User", Email = "admin@lms.com", Password = "admin123", Role = "Admin" },
                new User{FullName="Instructor User", Email="instructor@lms.com",Password="teacher123",Role="Instructor"},
                new User{FullName="Student User",Email="student123@lms.com",Password="student123",Role="Student"}
            };
                context.Users.AddRange(users);
                context.SaveChanges();
            }


        }
    }
}
