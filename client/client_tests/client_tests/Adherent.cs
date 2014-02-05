using System;
using System.Collections.Generic;

namespace gpcdb {
	public class Adherent : Participant {
		public string adresse { get; set; }
		public string barcode { get; set; }
		public int    id      { get; set; }
		
		public Adherent (int id, string adresse, string nom, string prenom, string barcode): base (nom, prenom) {
			this.id = id;
			this.adresse = adresse;
			this.barcode = barcode;
		}
	}
}

