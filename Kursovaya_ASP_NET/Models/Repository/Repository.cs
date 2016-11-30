using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursovaya_ASP_NET.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games { get { return context.Games; } }
    }
}