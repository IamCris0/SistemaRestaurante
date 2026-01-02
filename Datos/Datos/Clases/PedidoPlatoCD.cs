using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PedidoPlato = Entidades.Clases.PedidoPlato;

namespace Datos.Clases
{
    public class PedidoPlatoCD
    {
        public static List<CP_ListarPedidoPlato_FiltroResult> ListaPedidoPlatoFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarPedidoPlato_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar pedido plato", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarPedidoPlato(PedidoPlato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarPedidoPlato(oc.Idpedidoplato,oc.Idpedido, oc.Idplato, oc.Cantidad, oc.Subtotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla pedido plato", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarPedidoPlato(PedidoPlato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarPedidoPlato(oc.Idpedidoplato, oc.Idpedido, oc.Idplato, oc.Cantidad, oc.Subtotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla pedido plato", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarPedidoPlato(PedidoPlato oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarPedidoPlato(oc.Idpedidoplato);
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
