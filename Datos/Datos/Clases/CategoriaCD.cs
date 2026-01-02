using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categoria = Entidades.Clases.Categoria;

namespace Datos.Clases
{
    public class CategoriaCD
    {
        public static List<CP_ListarCategoria_FiltroResult> ListarCategoriaFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarCategoria_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar categoria", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCategoria(Categoria oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarCategoria(oc.Idcategoria, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla categoria", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarCategoria(Categoria oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarCategoria(oc.Idcategoria, oc.Nombre, oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla categoria", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarCategoria(Categoria oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarCargo(oc.Idcategoria);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla categoria", ex);
            }
            finally
            {
                DB = null;
            }
        }
        }
}
