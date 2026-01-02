using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Cliente
    {
        private int idcliente;
        private string cedula;
        private string nombre;
        private string apellido;
        private string telefono;
        private string direccion;
        private string email;

        public Cliente()
        {

        }

        public Cliente(int idcliente, string cedula, string nombre, string apellido, string telefono, string direccion, string email)
        {
            this.Idcliente = idcliente;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Email = email;
        }

        public int Idcliente { get => idcliente; set => idcliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
    }
}
