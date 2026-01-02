using System;
using System.Collections.Generic;
using System.Linq;
using Datos.LINQ;

namespace Datos.Clases
{
    public class CargosCD
    {
        public static List<CP_ListarCargosFiltroResult> ListarCargoFiltro(string valor)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    return dc.CP_ListarCargosFiltro(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar cargos: " + ex.Message, ex);
            }
        }

        public static void InsertarCargo(int idcargo, string nombre, string descripcion)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    dc.CP_InsertarCargo(idcargo, nombre, descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cargo: " + ex.Message, ex);
            }
        }

        public static void ActualizarCargo(int idcargo, string nombre, string descripcion)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    dc.CP_ActualizarCargo(idcargo, nombre, descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cargo: " + ex.Message, ex);
            }
        }

        public static void EliminarCargo(int idcargo)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    dc.CP_EliminarCargo(idcargo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cargo: " + ex.Message, ex);
            }
        }
    }
}