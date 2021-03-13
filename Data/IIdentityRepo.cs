using System.Collections.Generic;
using Identity.Models;

namespace Identity.Data
{
    public interface IIdentityRepo
    {
        IEnumerable<User> GetAllCommands();
        User GetCommandById(int ItemId);
    }
}