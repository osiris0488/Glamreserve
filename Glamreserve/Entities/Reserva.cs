namespace Glamreserve
{
	public class Reserva
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public Usuario Cliente { get; set; } = null!;

		public int EmpleadoId { get; set; }
		public Usuario Empleado { get; set; } = null!;

		public int ServicioId { get; set; }
		public Servicio Servicio { get; set; } = null!;

		public DateTime FechaHora { get; set; }
		public string Estado { get; set; } = "Pendiente"; // "Pendiente", "Confirmada", "Cancelada"
	}

}
