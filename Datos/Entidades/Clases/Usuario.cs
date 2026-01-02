using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Usuario
    {
        private string email;
        private string contrasena;

        public Usuario()
        {

        }

        public Usuario(string email, string contrasena)
        {
            this.Email = email;
            this.Contrasena = contrasena;
        }

        public string Email { get => email; set => email = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
