using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Validations
{
    public class ResponseMessage
    {
        public const string USER_INVALID_USERNAME_PASSWORD = "Invalid username or password";
        public const string USER_NOT_EXIST = "User not exist";
        public const string USER_NOT_ADDED_TO_ROLE = "Your subscription does not include these contents";
        public const string USER_NOT_CREATED = "User not Created";
        public const string USER_ALREADY_EXIST = "User already exist";
        public const string USER_IS_DISABLED = "User is Disabled";
    }
}
