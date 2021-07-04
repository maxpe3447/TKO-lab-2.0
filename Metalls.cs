using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKO_lab
{
	class Metalls
	{
		public Metalls() { }
		public Metalls(double ro, double alpha)
		{
			this.ro = ro;
			this.alpha = get_alpha();
		}

		public double get_ro() { return ro; }
		public double get_alpha() { return alpha; }

		private double ro;
		private double alpha;
	}
}
