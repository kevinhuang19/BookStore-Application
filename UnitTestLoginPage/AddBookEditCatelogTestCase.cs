using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    internal class AddBookEditCatelogTestCase
    {
        public Boolean checkForEmptyChar(string isbn , string title,  string author, string year ,   string ed ,  string pb ,  string pr ,   string cat)
        {
            if (isbn == "" || title == "" || author == "" || year == "" || ed == "" || pb == "" || pr == "" || cat == "")
            {
                return true; 
            }
            return false;   
        }

        public Boolean testIsbnLength(string isbn)
        {
            if (isbn.Length > 13 || isbn.Length < 10)
            {
                return true;
            }
            return false;
        }

        public Boolean testYear(string year)
        {
            if (year.Length != 4)
            {
                return true;
            }
            return false;
        }
    }
}
