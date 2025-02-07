using Microsoft.EntityFrameworkCore;


namespace Glamreserve
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Servicio> Servicios { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
		public DbSet<HorarioEmpleado> HorariosEmpleados { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>()
				.HasMany(u => u.Reservas)
				.WithOne(r => r.Cliente)
				.HasForeignKey(r => r.ClienteId);

			modelBuilder.Entity<Usuario>()
				.HasMany(u => u.Horarios)
				.WithOne(h => h.Empleado)
				.HasForeignKey(h => h.EmpleadoId);

			modelBuilder.Entity<Reserva>()
				.HasOne(r => r.Empleado)
				.WithMany()
				.HasForeignKey(r => r.EmpleadoId);
		}
	}

}
