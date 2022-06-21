using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
   public class MissatgeITV
    {
        String matricula;
        String missatge;

        public MissatgeITV(string matricula, string missatge)
        {
            this.matricula = matricula;
            this.missatge = missatge;
        }

        //getters and setters
        public String Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public String Missatge
        {
            get { return missatge; }
            set { missatge = value; }
        }

    }
}
