namespace Glamreserve
{
	public class HorarioEmpleado
	{
		public int Id { get; set; }
		public int EmpleadoId { get; set; }
		public Usuario Empleado { get; set; } = null!;
		public DateTime FechaHoraInicio { get; set; }
		public DateTime FechaHoraFin { get; set; }
		public bool Disponible { get; set; } = true;
	}

}
