﻿namespace Glamreserve
{
	public class Servicio
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public decimal Precio { get; set; }
		public int DuracionMinutos { get; set; }

		public List<Reserva>? Reservas { get; set; }
	}

}
