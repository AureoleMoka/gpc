using System;
using System.Collections.Generic;

namespace gpcdb
{
	public class Course {
		DateTime Date;
		int distance;
		int nombre_tours;
		Dictionary <string, Participant> participants;

		public Course (DateTime Date, int distance, int nombre_tours): this(Date, distance, nombre_tours) {
			participants = new Dictionary<string, Participant> ();
		}

		public void enregistrer_participant (string id_dossard, Participant P) {
			participants.Add (id_dossard, P);
		}
	}
}

