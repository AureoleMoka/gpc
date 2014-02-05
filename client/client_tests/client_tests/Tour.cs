using System;

namespace gpcdb
{
	public class Tour {
		DateTime temps;

		public Tour (DateTime D) {
			temps = D;
		}

		public Tour () {
			temps = DateTime.Now;
		}
	}
}

