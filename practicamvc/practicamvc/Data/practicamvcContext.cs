using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practicamvc.Models;

namespace practicamvc.Data
{
    public class practicamvcContext : DbContext
    {
        public practicamvcContext (DbContextOptions<practicamvcContext> options)
            : base(options)
        {
        }

        public DbSet<practicamvc.Models.ClienteModel> ClienteModel { get; set; } = default!;
    }
}
