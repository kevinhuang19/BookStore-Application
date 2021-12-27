using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    public class EmptyInputTest
    {
        public bool isEmpty(string username, string password) //check for the username or password being blank
        {
            if (password.Length == 0 || username.Length == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}