using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ClienteLN
    {
        public List<Cliente> ViewCliente(string valor)
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente oc;

            try
            {
                var auxLista = ClienteCD.ListarClienteFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Cliente(obj.IdCliente, obj.Cedula, obj.Nombres, obj.Apellidos,
                                     obj.Telefono, obj.Direccion, obj.Email);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar clientes", ex);
            }
            return lista;
        }

        public bool CreateCliente(Cliente oc)
        {
            try
            {
                ClienteCD.InsertarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar cliente", ex);
            }
        }

        public bool UpdateCliente(Cliente oc)
        {
            try
            {
                ClienteCD.ModificarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar cliente", ex);
            }
        }

        public bool DeleteCliente(Cliente oc)
        {
            try
            {
                ClienteCD.EliminarCliente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar cliente", ex);
            }
        }

    }
}
