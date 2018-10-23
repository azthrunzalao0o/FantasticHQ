using FamilyHomeWeb.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace FamilyHomeWeb.Controllers.EntityFramework
{
    public static class UserAccountDataController
    {
        public static List<UserAccount> GetUserAccounts()
        {
            List<UserAccount> userAccounts;
            using (FantasticHQEntities context = new FantasticHQEntities())
            {
                var query = from user in context.UserAccounts
                            select user;
                userAccounts = query.Distinct().ToList();
            }
            return userAccounts;
        }
    }
}