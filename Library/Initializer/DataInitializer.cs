using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Initializer
{
    public class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            string password1 = BCrypt.Net.BCrypt.HashPassword("123");
            string password2 = BCrypt.Net.BCrypt.HashPassword("1234");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() { ID = 1, UserName = "administrator", Password = password1, Role = Enums.Role.admin },
                new AppUser() { ID = 2, UserName = "Elif", Password = password2, Role = Enums.Role.user }
                );

            modelBuilder.Entity<Student>().HasData(
            new Student() { ID = 1, FirstName = "Melih", LastName = "Bayram", Gender = Enums.Gender.Erkek },
            new Student() { ID = 2, FirstName = "Merve", LastName = "Akdeniz", Gender = Enums.Gender.Kadın },
            new Student() { ID = 3, FirstName = "Mert", LastName = "Öden", Gender = Enums.Gender.Erkek },
            new Student() { ID = 4, FirstName = "Şule", LastName = "Çakır", Gender = Enums.Gender.Kadın }
            );

            modelBuilder.Entity<StudentDetail>().HasData(
            new StudentDetail() { ID = 1, StudentID = 1, SchoolNumber = "100", PhoneNumber = "05418965236", BirthDay = new DateTime(1997, 08, 15) },
            new StudentDetail() { ID = 2, StudentID = 2, SchoolNumber = "101", PhoneNumber = "05418965236", BirthDay = new DateTime(1997, 05, 18) },
            new StudentDetail() { ID = 3, StudentID = 3, SchoolNumber = "102", PhoneNumber = "05418965236", BirthDay = new DateTime(1992, 10, 04) },
            new StudentDetail() { ID = 4, StudentID = 4, SchoolNumber = "103", PhoneNumber = "05418965236",  BirthDay = new DateTime(1990, 11, 30) }
            );
        }
    }
}
