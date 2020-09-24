using System;

namespace AT02.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public DateTime Nascimento {get; set;}
        public string Login {get; set;}
        public string Senha { get; set; }
        public int Tipo {get; set;}
    }
}