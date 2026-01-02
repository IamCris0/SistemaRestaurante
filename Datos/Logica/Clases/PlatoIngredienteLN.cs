using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class PlatoIngredienteLN
    {
        public List<PlatoIngrediente> ViewPlatoIngrediente(string valor)
        {
            List<PlatoIngrediente> lista = new List<PlatoIngrediente>();
            PlatoIngrediente oc;

            try
            {
                var auxLista = PlatoIngredienteCD.ListarPlatoIngredienteFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new PlatoIngrediente(obj.IdPlatoIngrediente,
                                              obj.IdPlato,
                                              obj.IdIngrediente,
                                              obj.Cantidad);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar plato ingrediente", ex);
            }
            return lista;
        }

        public bool CreatePlatoIngrediente(PlatoIngrediente oc)
        {
            try
            {
                PlatoIngredienteCD.InsertarPlatoIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar plato ingrediente", ex);
            }
        }

        public bool UpdatePlatoIngrediente(PlatoIngrediente oc)
        {
            try
            {
                PlatoIngredienteCD.ModificarPlatoIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar plato ingrediente", ex);
            }
        }

        public bool DeletePlatoIngrediente(PlatoIngrediente oc)
        {
            try
            {
                PlatoIngredienteCD.EliminarPlatoIngrediente(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar plato ingrediente", ex);
            }
        }

    }
}
