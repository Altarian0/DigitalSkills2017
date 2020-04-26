using DigitalSkills2017.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSkills2017.Helper
{
    public class DataHelper
    {
        private static Session5Entities1 _context = new Session5Entities1();

        public static Session5Entities1 GetContext()
        {
            return _context;
        }
    }
}
