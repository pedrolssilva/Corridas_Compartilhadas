using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pedro_teste.Models
{
    public class Driver
    {
        public int id_motorista { get; set; }
        public string nm_motorista { get; set; }
        public string dt_nasc_motorista { get; set; }
        public decimal cpf_motorista { get; set; }
        public string modelo_carro_motorista { get; set; }
        public string status_motorista { get; set; }
        public char sexo_motorista { get; set; }
    }
}