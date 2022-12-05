using yatb_sharp.Database;
using yatb_sharp.Database.Models;

namespace yatb_sharp.Extensions;

public static class UserExtensions
{
    public static bool IsAdmin(this User user, ApplicationContext context)
    {
        return false; // TODO
    }
}