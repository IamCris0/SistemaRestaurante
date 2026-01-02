using Datos.Clases;
using Datos.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo = Entidades.Clases.Cargo;
using CargosCD = Datos.Clases.CargosCD;

namespace Logica.Clases
{
    public  class CargoLN
    {
        public List<Cargo > ViewCargo(string valor)
        {
            List<Cargo> lista = new List<Cargo>();
            Cargo oc;

            try
            {
                List<CP_ListarCargosFiltroResult> auxLista = CargosCD.ListarCargoFiltro(valor);
                foreach (CP_ListarCargosFiltroResult obj in auxLista)
                {
                    oc = new Cargo(obj.IdCargo, obj.Nombre, obj.Descripcion);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar los registros de viaje en la base de datos", ex);
            }
            finally
            {
            }
            return lista;
        }

        

        public bool CreateCargo(Cargo oc)
        {
            try
            {
                CargosCD.InsertarCargo(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar viaje en la base de datos", ex);
            }
        }

        public bool UpdateCargo(Cargo oc)
        {
            try
            {
                CargosCD.ModificarCargo(oc);
                return true;
            }
            catch (Exception)
            {
                throw new LogicaExcepciones("Error al actualizar viaje en la base de datos");
            }
        }

        public bool DeleteCargo(Cargo oc)
        {
            try
            {
                CargosCD.EliminarCargo(oc);
                return true;
            }
            catch (Exception)
            {
                throw new LogicaExcepciones("Error al eliminar viaje en la base de datos");
            }
        }
    }
}
