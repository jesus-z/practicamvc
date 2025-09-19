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

        public DbSet<practicamvc.Models.Clientes> ClientesModel { get; set; } = default!;
        public DbSet<practicamvc.Models.DetallePedidos> DetallePedidoModel { get; set; } = default!;
        public DbSet<practicamvc.Models.ErrorView> ErrorViewModel { get; set; } = default!;
        public DbSet<practicamvc.Models.Pedidos> PedidoModel { get; set; } = default!;
        public DbSet<practicamvc.Models.Productos> ProductoModel { get; set; } = default!;
    }
}
