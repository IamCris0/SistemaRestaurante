using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario = Entidades.Clases.Usuario;

namespace Datos.Clases
{
    public class UsuarioCD
    {
        public static void insertar(Entidades.Clases.Usuario oc)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarUsuario(oc.Email, oc.Contrasena);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar en la tabla usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static bool verificar(string correo, string contraseña)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    var usuario = DB.Usuario.FirstOrDefault(u => u.Email == correo);
                    if (usuario == null)
                    {
                        throw new DatosExcepciones("Usuario incorrecto");
                    }

                    if (usuario.Contraseña != contraseña)
                    {
                        throw new DatosExcepciones("Contraseña incorrecta");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones(ex.Message, ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
