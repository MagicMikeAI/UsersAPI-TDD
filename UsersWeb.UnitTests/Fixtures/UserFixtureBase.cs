using UsersWeb.API.Models;

namespace UsersWeb.UnitTests.Fixtures
{
    internal class UserFixtureBase
    {
        public static List<User> GetTestUsers()
        {
            return new()
            {
                new User {
                    Id = 1,
                    Name = "John Doe",
                    Email = " jd@aol.com",
                    Address = new Address()
                    {
                        Street = "123 Main Street",
                        City = "Wigan",
                        PostalCode = "WN2 2XX"
                    }
                },

                new User
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Email = "xd@test.com",
                    Address = new Address()
                    {
                        Street = "123 Main Street",
                        City = "London",
                        PostalCode = "LN2 2XX"
                    }
                },

                new User
                {
                    Id = 3,
                    Name = "John Smith",
                    Email = "JS@gmail.com",
                    Address = new Address()
                    {
                        Street = "123 Main Street",
                        City = "Manchester",
                        PostalCode = "MN2 2XX"
                    }

                },
            };
        }
    }
}
