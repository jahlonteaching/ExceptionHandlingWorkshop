using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWorkshop.Domain
{
    public class UserRepository : IUserRepository
    {
        List<User> IUserRepository.GetAllUsers()
        {
            return new List<User>()
            {
                new User("Jhon", "Doe"),
                new User("Mary", "Poppings"),
                new User("Brock", "Harrison"),
                new User("Sharon", "Stone"),
                new User("James", "Bayle")
            };
        }
    }
}
