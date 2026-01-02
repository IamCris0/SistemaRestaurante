using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosExcepciones : ApplicationException
    {
        public DatosExcepciones(string mens, Exception ex)
            : base(mens, ex)
        {
        }

        public DatosExcepciones(string mens)
            : base(mens)
        {
        }
    }
}
