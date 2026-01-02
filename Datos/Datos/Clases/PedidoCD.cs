using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedido = Entidades.Clases.Pedido;

namespace Datos.Clases
{
    public class PedidoCD
    {
        public static List<CP_ListarPedido_FiltroResult> ListaPedidoFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarPedido_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar pedido", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarPedido(Pedido oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarPedido(oc.Idpedido, oc.Fecha, oc.Total, oc.Estado, oc.Idcliente, oc.Idempleado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla pedido", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPedido(Pedido oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarPedido(oc.Idpedido, oc.Fecha, oc.Total, oc.Estado, oc.Idcliente, oc.Idempleado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla pedido", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPedido(Pedido oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarPedido(oc.Idpedido);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla pedido", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
