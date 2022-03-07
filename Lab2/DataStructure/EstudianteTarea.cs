using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class EstudianteTarea
    {
        private int hEstimadas, hReales;

        private User estudiante;
        private TareaGenerica tarea;

        public EstudianteTarea()
        {

        }

        public EstudianteTarea(int hEstimadas, int hReales, User estudiante)
        {
            this.hEstimadas = hEstimadas;
            this.hReales = hReales;
            this.estudiante = estudiante;
        }

        public void setEstudiante(User e)
        {
            this.estudiante = e;
        }

        public User getEstudiante()
        {
            return this.estudiante;
        }

        public void setHEstimadas(int he)
        {
            this.hEstimadas = he;
        }
        public int getHEstimadas()
        {
            return this.hEstimadas;
        }

        public void setHReales(int hr)
        {
            this.hReales = hr;
        }
        public int getHReales()
        {
            return this.hReales;
        }
    }
}
