using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class PedidoPlato
    {
        private int idpedidoplato;
        private int idpedido;
        private int idplato;
        private int cantidad;
        private decimal subtotal;

        public PedidoPlato()
        {

        }

        public PedidoPlato(int idpedidoplato, int idpedido, int idplato, int cantidad, decimal subtotal)
        {
            this.Idpedidoplato = idpedidoplato;
            this.Idpedido = idpedido;
            this.Idplato = idplato;
            this.Cantidad = cantidad;
            this.Subtotal = subtotal;
        }

        public int Idpedidoplato { get => idpedidoplato; set => idpedidoplato = value; }
        public int Idpedido { get => idpedido; set => idpedido = value; }
        public int Idplato { get => idplato; set => idplato = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
    }
}
