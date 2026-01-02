using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Reserva
    {
        private int idreserva;
        private DateTime fechahora;
        private int idcliente;
        private int idmesa;
        private int idplato;

        public Reserva()
        {

        }

        public Reserva(int idreserva, DateTime fechahora, int idcliente, int idmesa, int idplato)
        {
            this.Idreserva = idreserva;
            this.Fechahora = fechahora;
            this.Idcliente = idcliente;
            this.Idmesa = idmesa;
            this.Idplato = idplato;
        }

        public int Idreserva { get => idreserva; set => idreserva = value; }
        public DateTime Fechahora { get => fechahora; set => fechahora = value; }
        public int Idcliente { get => idcliente; set => idcliente = value; }
        public int Idmesa { get => idmesa; set => idmesa = value; }
        public int Idplato { get => idplato; set => idplato = value; }
    }
}
