using System.Collections.Generic;
using Identity.Models;

namespace Identity.Data
{
    public class MockIdentityRepo : IIdentityRepo
    {
        public IEnumerable<User> GetAllCommands()
        {
            var commands = new List<User>
            {
                new User{_id="4", name="Boil an egg", website="Boil", twitter="kettle a pen"},
            };
            return commands;
        }

        public User GetCommandById(int ItemId)
        {
            return new User{_id="5", name="Boil an egg", website="Boil", twitter="kettle a pen"};
        }
    }
}