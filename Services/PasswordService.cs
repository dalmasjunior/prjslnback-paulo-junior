using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Security;
namespace prjslnback_paulo_junior.Services
{
    public static class PasswordService
    {
        public static bool ValidatePassword(string pass)
        {
            return ValidateSizeUpperLowerSpecialChar(pass) && !ValidateRepeatedInSequenceChars(pass);
        }

        public static string GenerateRandomPassword()
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#_-";  
            Random random = new Random();  
    
            int size = random.Next(15, 32);  
    
            char[] chars = new char[size];  
            for (int i = 0; i < size; i++)  
            {  
                chars[i] = validChars[random.Next(0, validChars.Length)];  
            }  
            var newPassword = new string(chars);
            return ValidatePassword(newPassword) ? newPassword : GenerateRandomPassword();
        }

        private static bool ValidateSizeUpperLowerSpecialChar(string pass) 
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#_\-]).{15,32}$";
            return Regex.IsMatch(pass, pattern);
        }

        private static bool ValidateRepeatedInSequenceChars(string pass)
        {
            string pattern =  @"(.)\1";
            return Regex.IsMatch(pass, pattern);
        }
    }
}