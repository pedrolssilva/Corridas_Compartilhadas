using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedro_teste.Models
{
    public class Passenger
    {
        public int id_passageiro { get; set; }
        public string nm_passageiro { get; set; }
        public string dt_nasc_passageiro { get; set; }
        public decimal cpf_passageiro { get; set; }
        public char sexo_passageiro { get; set; }

    }
}