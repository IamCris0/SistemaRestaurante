using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Pedido
    {
        private int idpedido;
        private DateTime fecha;
        private decimal total;
        private string estado;
        private int idcliente;
        private int idempleado;

        public Pedido()
        {

        }

        public Pedido(int idpedido, DateTime fecha, decimal total, string estado, int idcliente, int idempleado)
        {
            this.Idpedido = idpedido;
            this.Fecha = fecha;
            this.Total = total;
            this.Estado = estado;
            this.Idcliente = idcliente;
            this.Idempleado = idempleado;
        }

        public int Idpedido { get => idpedido; set => idpedido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Idcliente { get => idcliente; set => idcliente = value; }
        public int Idempleado { get => idempleado; set => idempleado = value; }
    }
}
