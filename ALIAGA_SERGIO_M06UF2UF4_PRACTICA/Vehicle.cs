using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALIAGA_SERGIO_M06UF2UF4_PRACTICA
{
    public class Vehicle
    {
        String matricula; 
        String propietari;
        String marca;
        String model;
        int caballs;
        String motor;
        String t_neumatics;
        Boolean binfoITV;

        public Vehicle(string matricula, string propietari, string marca, string model, int caballs, string motor, string neumatics, bool binfoITV)
        {
            this.matricula = matricula;
            this.propietari = propietari;
            this.marca = marca;
            this.model = model;
            this.caballs = caballs;
            this.motor = motor;
            t_neumatics = neumatics;
            this.binfoITV = binfoITV;
        }

        //getters and setters
        public String Matricula 
        { 
            get { return matricula;}
            set { matricula = value; } 
        }
        public String Propietari
        {
            get { return propietari; }
            set { propietari = value; }
        }
        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public String Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Caballs
        {
            get { return caballs; }
            set { caballs = value; }
        }
        public String Motor
        {
            get { return motor; }
            set { motor = value; }
        }
        public String T_neumatics
        {
            get { return t_neumatics; }
            set { t_neumatics = value; }
        }
        public Boolean BinfoITV
        {
            get { return binfoITV; }
            set { binfoITV= value; }
        }


    }
}
