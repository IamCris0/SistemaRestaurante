using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plato = Entidades.Clases.Plato;

namespace Datos.Clases
{
    public class PlatoCD
    {
        public static List<CP_ListarPlato_FiltroResult> ListarPlatoFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarPlato_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar plato", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarPlato(Plato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarPlato(oc.Idplato, oc.Nombre, oc.Descripcion, oc.Precio, oc.Stock, oc.Idcategoria);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla plato", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPlato(Plato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarPlato(oc.Idplato, oc.Nombre, oc.Descripcion, oc.Precio, oc.Stock, oc.Idcategoria);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla plato", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPlato(Plato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarPlato(oc.Idplato);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla plato", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
