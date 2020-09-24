using System;

namespace AT02.Models
{
    public class Pacote
    {
        public string Nome { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Atrativos { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Retorno { get; set; }
        public int IdCriador { get; set; }

        public int IdPacote { get; set; }
    }
}