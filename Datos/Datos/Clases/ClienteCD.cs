using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente = Entidades.Clases.Cliente;

namespace Datos.Clases
{
    public class ClienteCD
    {
        public static List<CP_ListarCliente_FiltroResult> ListarClienteFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarCliente_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCliente(Cliente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarCliente(oc.Idcliente, oc.Cedula, oc.Nombre, oc.Apellido, oc.Telefono, oc.Direccion, oc.Email);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarCliente(Cliente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarCliente(oc.Idcliente, oc.Cedula, oc.Nombre, oc.Apellido, oc.Telefono, oc.Direccion, oc.Email);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarCliente(Cliente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarCliente(oc.Idcliente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
