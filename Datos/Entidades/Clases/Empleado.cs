using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Empleado
    {
        private int idempleado;
        private string cedula;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private decimal salario;
        private int idcargo;

        public Empleado()
        {

        }

        public Empleado(int idempleado, string cedula, string nombre, string apellido, string telefono, string email, decimal salario, int idcargo)
        {
            this.Idempleado = idempleado;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Email = email;
            this.Salario = salario;
            this.Idcargo = idcargo;
        }

        public int Idempleado { get => idempleado; set => idempleado = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public decimal Salario { get => salario; set => salario = value; }
        public int Idcargo { get => idcargo; set => idcargo = value; }
    }
}
