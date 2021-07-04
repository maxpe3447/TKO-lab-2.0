using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKO_lab
{
    class Rezistor// : mainForm
    {
        public	Rezistor() { }
        public Rezistor(double value)  { this.close_zone = value; }
        public double get_close_zone(){ return close_zone; }
        private double close_zone;
    }
}
