using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Asignatura
    {
        private String codigo;
        private string nombre;

        private List<TareaGenerica> tareas;
        private List<GrupoClase> clases;

        public void setCodigo(string codigo)
        {
            this.codigo = codigo;
        }

        internal string getCodigo()
        {
            return this.codigo;
        }
    }
}
