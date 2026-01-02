using Microsoft.EntityFrameworkCore;

namespace RestauranteMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets - Tablas de la base de datos
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPlato> PedidoPlatos { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales si son necesarias
            modelBuilder.Entity<Cargo>()
                .HasMany(c => c.Empleados)
                .WithOne(e => e.Cargo)
                .HasForeignKey(e => e.IdCargo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Platos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Pedidos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Pedidos)
                .WithOne(p => p.Empleado)
                .HasForeignKey(p => p.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mesa>()
                .HasMany(m => m.Reservas)
                .WithOne(r => r.Mesa)
                .HasForeignKey(r => r.IdMesa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.PedidoPlatos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Plato>()
                .HasMany(p => p.PedidoPlatos)
                .WithOne(pp => pp.Plato)
                .HasForeignKey(pp => pp.IdPlato)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Plato>()
                .HasMany(p => p.Reservas)
                .WithOne(r => r.Plato)
                .HasForeignKey(r => r.IdPlato)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
