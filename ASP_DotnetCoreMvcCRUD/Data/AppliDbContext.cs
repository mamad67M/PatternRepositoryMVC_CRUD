using ASP_DotnetCoreMVC_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DotnetCoreMVC_CRUD.Data
{
    public class AppliDbContext: DbContext
    {
        public AppliDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Unit> units { get; set; }
    }
}
