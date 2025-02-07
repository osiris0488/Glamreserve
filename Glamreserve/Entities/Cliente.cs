﻿namespace Glamreserve
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Rol { get; set; } = "Cliente"; // Puede ser "Cliente" o "Empleado"

		public List<Reserva>? Reservas { get; set; }
		public List<HorarioEmpleado>? Horarios { get; set; }
	}

}
