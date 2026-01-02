using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class PedidoLN
    {
        public List<Pedido> ViewPedido(string valor)
        {
            List<Pedido> lista = new List<Pedido>();
            Pedido oc;

            try
            {
                var auxLista = PedidoCD.ListaPedidoFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Pedido(obj.IdPedido, obj.Fecha, obj.Total,
                                    obj.Estado, obj.IdCliente, obj.IdEmpleado);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar pedidos", ex);
            }
            return lista;
        }

        public bool CreatePedido(Pedido oc)
        {
            try
            {
                PedidoCD.InsertarPedido(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar pedido", ex);
            }
        }

        public bool UpdatePedido(Pedido oc)
        {
            try
            {
                PedidoCD.ModificarPedido(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar pedido", ex);
            }
        }

        public bool DeletePedido(Pedido oc)
        {
            try
            {
                PedidoCD.EliminarPedido(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar pedido", ex);
            }
        }

    }
}
