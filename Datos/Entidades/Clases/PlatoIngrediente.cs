using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class PlatoIngrediente
    {
        private int idplatoingrediente;
        private int idplato;
        private int idingrediente;
        private decimal cantidad;

        public PlatoIngrediente()
        {
        }

        public PlatoIngrediente(int idplatoingrediente, int idplato, int idingrediente, decimal cantidad)
        {
            this.Idplatoingrediente = idplatoingrediente;
            this.Idplato = idplato;
            this.Idingrediente = idingrediente;
            this.Cantidad = cantidad;
        }

        public int Idplatoingrediente { get => idplatoingrediente; set => idplatoingrediente = value; }
        public int Idplato { get => idplato; set => idplato = value; }
        public int Idingrediente { get => idingrediente; set => idingrediente = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
    }
}
