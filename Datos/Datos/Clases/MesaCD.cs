using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesa = Entidades.Clases.Mesa;

namespace Datos.Clases
{
    public class MesaCD
    {
        public static List<CP_ListarMesa_FiltroResult> ListarMesaFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarMesa_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar mesa", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarMesa(Mesa oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarMesa(oc.Idmesa, oc.Numero, oc.Capacidad, oc.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla mesa", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarMesa(Mesa oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarMesa(oc.Idmesa, oc.Numero, oc.Capacidad, oc.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla mesa", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarMesa(Mesa oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarMesa(oc.Idmesa);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla mesa", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
