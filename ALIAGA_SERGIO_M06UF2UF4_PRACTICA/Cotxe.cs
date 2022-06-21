using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
   public class Cotxe : Vehicle
    {
        String t_sostre;
        String t_porta;

        public Cotxe(String matricula, String propietari, String marca, String model, int caballs, String motor, String neumatics, Boolean binfoITV, String t_sostre, String t_porta) : base(matricula, propietari, marca, model, caballs, motor, neumatics, binfoITV)
        {
            this.t_sostre = t_sostre;
            this.t_porta = t_porta;
        }

        //getters and setters
        public String T_sostre
        {
            get { return t_sostre; }
            set { t_sostre = value; }
        }
        public String T_porta
        {
            get { return t_porta; }
            set { t_porta = value; }
        }
    }
}
