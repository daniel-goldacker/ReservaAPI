using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservasAPI.Models;

namespace ReservasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : Controller
    {
        private IRepositorio repository;
        public ReservasController(IRepositorio repositorio) => repository = repositorio;

        [HttpGet]
        public IEnumerable<Reserva> Get() => repository.Reservas;

        [HttpGet("{id}")]
        public Reserva Get(int id) => repository[id];

        [HttpPost]
        public Reserva Post([FromBody] Reserva reserva) =>
        repository.AdicionarReserva(new Reserva
        {
            Nome = reserva.Nome,
            LocalInicioLocacao = reserva.LocalInicioLocacao,
            LocalFimLocacao = reserva.LocalFimLocacao,
            Veiculo = reserva.Veiculo
        });

        [HttpPut]
        public Reserva Put([FromBody] Reserva reserva) => repository.AlterarReserva(reserva);

        [HttpPatch]
        public Reserva Patch([FromBody] Reserva reserva) => repository.InserirAlterarReserva(reserva);
        
        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeletarReserva(id);
    }
}
