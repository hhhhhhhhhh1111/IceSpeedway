﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IceSpeedway.utils
{
    public static class InputValidator
    {
        public static bool IsValidEmail(this string email)
        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        public static bool IsValidPassword(this string password)
        {
            return password.Length >= 6;
        }
    }
}
