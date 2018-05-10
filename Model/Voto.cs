using System;

namespace Model
{
    public class Voto
    {
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
        public int IdRestaurante { get; set; }
        public string NomeRestaurante { get; set; }
    }
}
