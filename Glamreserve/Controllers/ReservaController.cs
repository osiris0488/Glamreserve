using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Glamreserve.Controllers;
using Glamreserve.DTOs;

namespace Glamreserve.Controllers
{
	[ApiController]
	[Route("api/reservas")]
	public class ReservaController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ReservaController(AppDbContext context)
		{
			_context = context;
		}

		// Crear una nueva reserva
		[HttpPost]
		public async Task<ActionResult<ReservaResponse>> CrearReserva([FromBody] ReservaRequest request)
		{
			var reserva = new Reserva
			{
				ClienteId = request.ClienteId,
				ServicioId = request.ServicioId,
				FechaHora = request.FechaHora,
				Estado = "Pendiente"
			};

			_context.Reservas.Add(reserva);
			await _context.SaveChangesAsync();

			return new ReservaResponse
			{
				Id = reserva.Id,
				ClienteNombre = _context.Clientes.Find(reserva.ClienteId)?.Nombre,
				ServicioNombre = _context.Servicios.Find(reserva.ServicioId)?.Nombre,
				FechaHora = reserva.FechaHora,
				Estado = reserva.Estado
			};
		}

		// Obtener todas las reservas
		[HttpGet]
		public async Task<ActionResult<List<ReservaResponse>>> ObtenerReservas()
		{
			var reservas = await _context.Reservas
				.Include(r => r.Cliente)
				.Include(r => r.Servicio)
				.Select(r => new ReservaResponse
				{
					Id = r.Id,
					ClienteNombre = r.Cliente.Nombre,
					ServicioNombre = r.Servicio.Nombre,
					FechaHora = r.FechaHora,
					Estado = r.Estado
				})
				.ToListAsync();

			return Ok(reservas);
		}
	}
}
