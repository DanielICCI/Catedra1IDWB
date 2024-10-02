using Catedra1.Models;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
    public static void SeedUsers(DbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User {Rut}
                new User { Rut = "12345678-9", Name = "Juan Perez", Email = "juan@example.com", Gender = "masculino", BirthDate = new DateTime(1990, 5, 10) },
                new User { Rut = "98765432-1", Name = "Maria Lopez", Email = "maria@example.com", Gender = "femenino", BirthDate = new DateTime(1985, 3, 15) },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}