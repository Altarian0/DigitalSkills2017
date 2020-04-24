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
        private static Session5Entities _context = new Session5Entities();

        public static Session5Entities GetContext()
        {
            return _context;
        }
    }
}
