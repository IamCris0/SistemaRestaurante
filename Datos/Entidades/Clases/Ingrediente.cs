using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Ingrediente
    {
        private int idingrediente;
        private string nombre;
        private decimal cantidad;
        private string unidadmedida;

        public Ingrediente()
        {

        }

        public Ingrediente(int idingrediente, string nombre, decimal cantidad, string unidadmedida)
        {
            this.Idingrediente = idingrediente;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Unidadmedida = unidadmedida;
        }

        public int Idingrediente { get => idingrediente; set => idingrediente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public string Unidadmedida { get => unidadmedida; set => unidadmedida = value; }
    }
}
