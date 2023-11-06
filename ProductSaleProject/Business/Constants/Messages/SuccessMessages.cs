using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants.Messages
{
    public static class SuccessMessages
    {
        public static string EntityAdded = "Entity Added";
        public static string EntityUpdated = "Entity Updated";
        public static string EntityDeleted = "Entity Deleted";
        public static string EntityByEntityId = "Entity is served with Entity Id";
        public static string EntityAllListed = "All Entities are listed";
        public static string GetAllByEntityPrice = "Entities between these interval are listed";
        public static string CategoryById = "Products are listed by Category Id";
        public static string EntityDetails = "Entity details are listed";
        public static string EntityNumberByCategoryExceeded = "The number of units in a category should lower than 10";
        public static string UserRegistered = "User is registered";
        public static string SuccessfulLogin = "Login is successfull";
        public static string AccessTokenCreated = "Access token is created";
    }
}
