using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class MesaLN
    {
        public List<Mesa> ViewMesa(string valor)
        {
            List<Mesa> lista = new List<Mesa>();
            Mesa oc;

            try
            {
                var auxLista = MesaCD.ListarMesaFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Mesa(obj.IdMesa, obj.Numero,
                                  obj.Capacidad, obj.Estado);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar mesas", ex);
            }
            return lista;
        }

        public bool CreateMesa(Mesa oc)
        {
            try
            {
                MesaCD.InsertarMesa(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar mesa", ex);
            }
        }

        public bool UpdateMesa(Mesa oc)
        {
            try
            {
                MesaCD.ModificarMesa(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar mesa", ex);
            }
        }

        public bool DeleteMesa(Mesa oc)
        {
            try
            {
                MesaCD.EliminarMesa(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar mesa", ex);
            }
        }

    }
}
