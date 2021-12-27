using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    internal class FirstCharTest
    {
        public Boolean checkFirstChar(string username, string password) //check the first character of the password to ensure that it starts with a letter
        {
            string pwClone = password.ToLower();
            if (pwClone[0] >= 65 && pwClone[0] <= 90) {
                return true;
            }
            return false;
        }
    }
}