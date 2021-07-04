using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKO_lab
{
    class Phizics
    {
        private const double _PI = 3.1415;

        public byte[] Term = new byte[] { 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 };//[14];
        public double[] R_arr = new double[14];
        public double[] R_termo = new double[14];


        double R_zero;
        double rand_error;

        double R_zero_termo;
        public double RZeroTermo
        {
            get
            {
                return R_zero_termo;
            }
        }
        double length;
        public double Lenght
        {
            get
            {
                return length;
            }
        }
        double diametr;
        public double Diametr
        {
            get
            {
                return diametr;
            }
        }
        double _S;
        public double S
        {
            get
            {
                return _S;
            }
        }
        public double get_close_zone() { return rez.get_close_zone(); }
        public double get_ro() { return metal.get_ro(); }
        Rezistor rez;
        Metalls metal;

        public Phizics(Rezistor rez, Metalls metal, Decimal length, Decimal diametr)
        {
            this.rez = rez;
            this.metal = metal;
            this.length = Decimal.ToDouble(length);
            this.diametr = Decimal.ToDouble(diametr);
            calc_S();
            calc_R_zero();
            calc_R();
            calc_R_zero_termo();
            calc_R_termo();
        }

        void calc_S()
        {
            diametr *= 0.001;
            _S = (_PI * (diametr * diametr)) / 4;
        }

        void calc_R_zero()
        {

            R_zero = (metal.get_ro() * length) / _S;
        }

        void calc_R()
        {

            for (int i = 0; i < 14; i++)
            {
                Random rand = new Random(DateTime.Now.Millisecond + i * 3);

                rand_error = rand.Next(1, 10) * 0.01;
                R_arr[i] = R_zero * ((1 + (double)metal.get_alpha() * Term[i]) / (1 + (double)metal.get_alpha() * 20)) * 1000;
                R_arr[i] += rand_error;
            }
        }

        void calc_R_zero_termo()
        {
            Random rand = new Random(DateTime.Now.Millisecond * 3);
            R_zero_termo = rand.Next(0, 500);
            R_zero_termo /= 1000;
        }

        void calc_R_termo()
        {
            short Kelvin = 273;
            double Eg = rez.get_close_zone();

            for (int i = 0; i < 14; i++)
            {
                R_termo[i] = R_zero_termo * 0.001 * Math.Exp(5797.0 * Eg / (Term[i] + Kelvin));
            }
        }
    }
}
