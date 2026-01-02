using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Plato
    {
        private int idplato;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private int stock;
        private int idcategoria;

        public Plato()
        {

        }

        public Plato(int idplato, string nombre, string descripcion, decimal precio, int stock, int idcategoria)
        {
            this.Idplato = idplato;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.Idcategoria = idcategoria;
        }

        public int Idplato { get => idplato; set => idplato = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Idcategoria { get => idcategoria; set => idcategoria = value; }
    }
}
