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

        public DbSet<practicamvc.Models.ClientesModel> ClienteModel { get; set; } = default!;
        public DbSet<practicamvc.Models.DetallePedidoModel> DetallePedidoModel { get; set; } = default!;
        public DbSet<practicamvc.Models.ErrorViewModel> ErrorViewModel { get; set; } = default!;
        public DbSet<practicamvc.Models.PedidoModel> PedidoModel { get; set; } = default!;
        public DbSet<practicamvc.Models.ProductoModel> ProductoModel { get; set; } = default!;
    }
}
