using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OrderDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
