using Datos.Clases;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;

namespace Logica.Clases
{
    public class UsuarioLN
    {
        public bool VerificarUsuario(string nombre, string contraseña)
        {
            try
            {
                return UsuarioCD.verificar(nombre, contraseña);
            }
            catch (DatosExcepciones ex)
            {
                throw new LogicaExcepciones(ex.Message, ex);
            }
        }

        public bool InsertarUsuario(Usuario oc)
        {
            try
            {
                UsuarioCD.insertar(oc);
                return true;
            }
            catch (DatosExcepciones ex)
            {
                throw new LogicaExcepciones("Error al insertar el usuario en la base de datos.", ex);
            }
        }
    }
}
