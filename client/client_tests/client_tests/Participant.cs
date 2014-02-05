using System;

namespace gpcdb
{
	public class Participant {
		public string nom    { get; set; }
		public string prenom { get; set; }

		public Participant (string nom, string prenom) {
			this.nom = nom;
			this.prenom = prenom;
		}
	}
}

