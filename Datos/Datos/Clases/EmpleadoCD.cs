using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleado = Entidades.Clases.Empleado;

namespace Datos.Clases
{
    public class EmpleadoCD
    {
        public static List<CP_ListarEmpleado_FiltroResult> ListaEmpleadoFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarEmpleado_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarEmpleado(Empleado oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarEmpleado(oc.Idempleado, oc.Cedula, oc.Nombre, oc.Apellido, oc.Telefono, oc.Email, oc.Salario, oc.Idcargo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarEmpleado(Empleado oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarEmpleado(oc.Idempleado, oc.Cedula, oc.Nombre, oc.Apellido, oc.Telefono, oc.Email, oc.Salario, oc.Idcargo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarEmpleado(Empleado oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarEmpleado(oc.Idempleado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla empleado", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
