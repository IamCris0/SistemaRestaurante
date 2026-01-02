using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ReservaLN
    {
        public List<Reserva> ViewReserva(string valor)
        {
            List<Reserva> lista = new List<Reserva>();
            Reserva oc;

            try
            {
                var auxLista = ReservaCD.ListarReservaFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Reserva(obj.IdReserva, obj.FechaHora,
                                     obj.IdCliente, obj.IdMesa, obj.IdPlato);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar reservas", ex);
            }
            return lista;
        }

        public bool CreateReserva(Reserva oc)
        {
            try
            {
                ReservaCD.InsertarReserva(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar reserva", ex);
            }
        }

        public bool UpdateReserva(Reserva oc)
        {
            try
            {
                ReservaCD.ModificarReserva(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar reserva", ex);
            }
        }

        public bool DeleteReserva(Reserva oc)
        {
            try
            {
                ReservaCD.EliminarReserva(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar reserva", ex);
            }
        }

    }
}
