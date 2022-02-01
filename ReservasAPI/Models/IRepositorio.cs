using System.Collections.Generic;

namespace ReservasAPI.Models
{
    public interface IRepositorio
    {
        IEnumerable<Reserva> Reservas { get; }
        Reserva this[int id] { get;}
        Reserva AdicionarReserva(Reserva reserva);
        Reserva AlterarReserva(Reserva reserva);
        Reserva InserirAlterarReserva(Reserva reserva);
        void DeletarReserva(int id);
    }
}
