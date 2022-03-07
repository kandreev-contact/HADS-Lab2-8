using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class TareaGenerica
    {
        private String codigo;
        private String descripcion;
        private int hEstimadas;
        private bool explotacion;
        private String tipoTarea;

        private List<EstudianteTarea> tareas;
        private Asignatura asignatura;
    }
}
