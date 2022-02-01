using System;
using System.Collections.Generic;

namespace ReservasAPI.Models
{
    public class Repositorio: IRepositorio
    {
        private Dictionary<int, Reserva> itens;

        public Repositorio()
        {
            itens = new Dictionary<int, Reserva>();
            new List<Reserva>
            {
                new Reserva {ReservaID=1, Nome = "Daniel", LocalInicioLocacao = "São Paulo", LocalFimLocacao="Lins" },
                new Reserva {ReservaID=2, Nome = "Bruna", LocalInicioLocacao = "Campinas", LocalFimLocacao="São Paulo" },
                new Reserva {ReservaID=3, Nome = "Bernardo", LocalInicioLocacao = "Jundiaí", LocalFimLocacao="Campinas" }
            }.ForEach(r => AdicionarReserva(r));
        }
        
        public Reserva this[int id] => itens.ContainsKey(id) ? itens[id] : null;
        public IEnumerable<Reserva> Reservas => itens.Values;

        public Reserva AdicionarReserva(Reserva reserva)
        {
            if (reserva.ReservaID == 0)
            {
                int key = itens.Count;
                while (itens.ContainsKey(key)) { key++; };
                reserva.ReservaID = key;
            }
            itens[reserva.ReservaID] = reserva;
            return reserva;
        }


        public Reserva AlterarReserva(Reserva reserva)
        {
            itens[reserva.ReservaID] = reserva;
            return reserva;
        }

        public void DeletarReserva(int id)
        {
            itens.Remove(id);
        }

        public Reserva InserirAlterarReserva(Reserva reserva)
        {
            if (itens.ContainsKey(reserva.ReservaID))
            {
                AlterarReserva(reserva);
            }
            else
            {
                AdicionarReserva(reserva);
            }
      
            return reserva;
        }
    }
}
