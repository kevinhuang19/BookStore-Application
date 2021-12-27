using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    public class InvalidCharsTest
    {
        public bool hasInvalidChars(string username, string password) { //check the password for invalid characters (non number, non letter)
            for (int i = 0; i < password.Length; i++) {
                if (!(password[i] >= 48 && password[i] <= 57) && !(password[i] >= 65 && password[i] <= 90 || password[i] >= 97 && password[i] <= 122)) {
                    return true;
                }
            }
            return false;
        }
    }
}
