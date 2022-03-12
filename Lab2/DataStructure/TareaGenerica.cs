using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class TareaGenerica
    {
        private String codigo;
        private String descripcion;
        private int hEstimadas;
        private bool explotacion;
        private String tipoTarea;

        private List<EstudianteTarea> tareas;
        private Asignatura asignatura;

        public TareaGenerica(String codigo, String descripcion, int hEstimadas, bool explotacion, String tipoTarea, Asignatura asignatura)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.hEstimadas = hEstimadas;
            this.explotacion = explotacion;
            this.asignatura = asignatura;
            this.tipoTarea = tipoTarea;
        }

        public String getCodigo()
        {
            return this.codigo;
        }

        public String getDescription()
        {
            return this.descripcion;
        }

        public String getCodAsignatura()
        {
            return this.asignatura.getCodigo();
        }

        public int getHEstimadas()
        {
            return this.hEstimadas;
        }

        public bool getExplotacion()
        {
            return this.explotacion;
        }

        public String getTipoTarea()
        {
            return this.tipoTarea;
        }
    }
}
