using System;

namespace Glamreserve
{
	public class ReservaRequest
	{
		public int ClienteId { get; set; }
		public int ServicioId { get; set; }
		public DateTime FechaHora { get; set; }
	}
}
