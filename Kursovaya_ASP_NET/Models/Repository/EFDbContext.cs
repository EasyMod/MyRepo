using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Kursovaya_ASP_NET.Models.Repository
{

    public class EFDbContext : DbContext
    {

        public EFDbContext()
        {
            //SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            //b.DataSource = "TESTER";
            //b.InitialCatalog = "Kursovaya_ASP_NET";
            //b.IntegratedSecurity = true;
            //b.Pooling = false;
            
            //Database.Connection.ConnectionString = b.ConnectionString;
            
        }
        public DbSet<Game> Games { get; set; }
    }
}