﻿using System;
namespace ReservasAPI.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public string Nome { get; set; }
        public string LocalInicioLocacao { get; set; }
        public string  LocalFimLocacao { get; set; }
    }
}
