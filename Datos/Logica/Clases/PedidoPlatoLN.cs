using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class PedidoPlatoLN
    {
        public List<PedidoPlato> ViewPedidoPlato(string valor)
        {
            List<PedidoPlato> lista = new List<PedidoPlato>();
            PedidoPlato oc;

            try
            {
                var auxLista = PedidoPlatoCD.ListaPedidoPlatoFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new PedidoPlato(obj.IdPedidoPlato, obj.IdPedido,
                                         obj.IdPlato, obj.Cantidad, obj.Subtotal);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar pedido plato", ex);
            }
            return lista;
        }

        public bool CreatePedidoPlato(PedidoPlato oc)
        {
            try
            {
                PedidoPlatoCD.InsertarPedidoPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar pedido plato", ex);
            }
        }

        public bool UpdatePedidoPlato(PedidoPlato oc)
        {
            try
            {
                PedidoPlatoCD.ModificarPedidoPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar pedido plato", ex);
            }
        }

        public bool DeletePedidoPlato(PedidoPlato oc)
        {
            try
            {
                PedidoPlatoCD.EliminarPedidoPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar pedido plato", ex);
            }
        }

    }
}
