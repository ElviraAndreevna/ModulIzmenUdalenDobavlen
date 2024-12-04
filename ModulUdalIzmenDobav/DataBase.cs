using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulUdalIzmenDobav
{
    class DataBase
    {
        private static ModulEntities2 _context;
        public static ModulEntities2 GetContext()
        {
            CreateContxet();
            return _context;
        }
        private static void CreateContxet()
        {
            if (_context == null)
                _context = new ModulEntities2();
        }
        public static void SaveChanges()
        {
            CreateContxet();
            _context.SaveChanges();
            _context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }
    }
}
