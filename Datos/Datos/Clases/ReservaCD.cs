using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reserva = Entidades.Clases.Reserva;

namespace Datos.Clases
{
    public class ReservaCD
    {
        public static List<CP_ListarReserva_FiltroResult> ListarReservaFiltro(string val)
        {
            BDRestauranteDataContext DB = null;
            try
            {
                using (DB = new BDRestauranteDataContext())
                {
                    return DB.CP_ListarReserva_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarReserva(Reserva oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_InsertarReserva(oc.Idreserva, oc.Fechahora, oc.Idcliente, oc.Idmesa, oc.Idplato);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ModificarReserva(Reserva oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_ModificarReserva(oc.Idreserva, oc.Fechahora, oc.Idcliente, oc.Idmesa, oc.Idplato);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar tabla reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void EliminarReserva(Reserva oc)
        {

            BDRestauranteDataContext DB = null;
            try
            {

                using (DB = new BDRestauranteDataContext())
                {
                    DB.CP_EliminarReserva(oc.Idreserva);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar tabla reserva", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
