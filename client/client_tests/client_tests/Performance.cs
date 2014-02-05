using System;
using System.Collections.Generic;

namespace gpcdb
{
	public class Performance {
		List<Tour> liste_tours;
		Course course;

		public Performance (Course course, List<Tour> liste_tours) {
			this.course = course;
			this.liste_tours = liste_tours;
		}
	}
}

