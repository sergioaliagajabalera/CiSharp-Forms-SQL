using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
    public class Moto : Vehicle
    {
        String t_cupula;
        Boolean bmaleta;

        public Moto(String matricula, String propietari, String marca, String model, int caballs, String motor, String neumatics, Boolean binfoITV, String t_cupula,Boolean bmaleta) : base(matricula, propietari, marca, model, caballs, motor, neumatics, binfoITV)
        {
            this.t_cupula = t_cupula;
            this.bmaleta = bmaleta;
        }

        //getters and setters
        public String T_cupula
        {
            get { return t_cupula; }
            set { t_cupula = value; }
        }
        public Boolean Bmaleta
        {
            get { return bmaleta; }
            set { bmaleta = value; }
        }
    }
}
