using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo = Entidades.Clases.Cargo;

namespace Datos.Clases
{
    public class CargosCD
    {
        public static List<CP_ListarCargosFiltroResult> ListarCargoFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarCargosFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCargo(Cargo oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarCargo(oc.Idcargo, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarCargo(Cargo oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarCargo(oc.Idcargo, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarCargo(Cargo oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarCargo(oc.Idcargo);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla cargo", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
