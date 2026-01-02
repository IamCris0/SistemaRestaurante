using Datos.Clases;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class PlatoLN
    {
        public List<Plato> ViewPlato(string valor)
        {
            List<Plato> lista = new List<Plato>();
            Plato oc;

            try
            {
                var auxLista = PlatoCD.ListarPlatoFiltro(valor);
                foreach (var obj in auxLista)
                {
                    oc = new Plato(obj.IdPlato, obj.Nombre, obj.Descripcion,
                                   obj.Precio, obj.Stock, obj.IdCategoria);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar platos", ex);
            }
            return lista;
        }

        public bool CreatePlato(Plato oc)
        {
            try
            {
                PlatoCD.InsertarPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar plato", ex);
            }
        }

        public bool UpdatePlato(Plato oc)
        {
            try
            {
                PlatoCD.ModificarPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al actualizar plato", ex);
            }
        }

        public bool DeletePlato(Plato oc)
        {
            try
            {
                PlatoCD.EliminarPlato(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar plato", ex);
            }
        }

    }
}
