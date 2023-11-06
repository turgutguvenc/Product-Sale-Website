using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants.Messages
{
    public static class ErrorMessages
    {
        public static string UserNotFound = "User not found error";
        public static string PasswordError = "Password not correct";
        public static string AuthorizationDenied = "Unauthorized Access Attempt";
        public static string EntityNameInvalid = "Entity name is invalid";
        public static string UserAlreadyExists = "User already exists";
        public static string EntityAlreadyExists = "This Entity name already exists";
        public static string EntityIsNotValid = "This entity is not valid";
        public static string NoEntityFound = "No entity is found";
    }
}
