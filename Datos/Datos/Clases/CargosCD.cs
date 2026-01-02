using Datos.LINQ;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Clases
{
    public class CargosCD
    {
        public static List<CP_ListarCargosFiltroResult> ListarCargoFiltro(string valor)
        {
            try
            {
                // ⭐ Usar la cadena de conexión global
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

        public static void InsertarCargo(Cargo cargo)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    dc.CP_InsertarCargo(cargo.Idcargo, cargo.Nombre, cargo.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cargo: " + ex.Message, ex);
            }
        }

        public static void ActualizarCargo(Cargo cargo)
        {
            try
            {
                string connectionString = ConnectionStringManager.GetConnectionString();

                using (BDRestauranteDataContext dc = new BDRestauranteDataContext(connectionString))
                {
                    dc.CP_ModificarCargo(cargo.Idcargo, cargo.Nombre, cargo.Descripcion);
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