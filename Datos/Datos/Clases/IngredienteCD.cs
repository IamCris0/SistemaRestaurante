using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingrediente = Entidades.Clases.Ingrediente;

namespace Datos.Clases
{
    public class IngredienteCD
    {
        public static List<CP_ListarIngrediente_FiltroResult> ListarIngredienteFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarIngrediente_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarIngrediente(Ingrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarIngrediente(oc.Idingrediente, oc.Nombre, oc.Cantidad, oc.Unidadmedida);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarIngrediente(Ingrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarIngrediente(oc.Idingrediente, oc.Nombre, oc.Cantidad, oc.Unidadmedida);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarIngrediente(Ingrediente oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarIngrediente(oc.Idingrediente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla ingrediente", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
