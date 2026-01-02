using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatoIngrediente = Entidades.Clases.PlatoIngrediente;

namespace Datos.Clases
{
    public class PlatoIngredienteCD
    {
        public static List<CP_ListarPlatoIngrediente_FiltroResult> ListarPlatoIngredienteFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarPlatoIngrediente_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar plato ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarPlatoIngrediente(PlatoIngrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarPlatoIngrediente(oc.Idingrediente, oc.Idplato, oc.Idplatoingrediente, oc.Cantidad);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla plato ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPlatoIngrediente(PlatoIngrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarPlatoIngrediente(oc.Idplatoingrediente , oc.Idplato, oc.Idingrediente, oc.Cantidad);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla plato ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPlatoIngrediente(PlatoIngrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarPlatoIngrediente(oc.Idplatoingrediente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla plato ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
