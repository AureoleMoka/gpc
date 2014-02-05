using System;

namespace gpcclient {
	public class Adherent {
		string adresse, nom, prenom, barcode;
		int id_dossard;

		public Adherent (string adresse, string nom, string prenom, string barcode) {
			this.adresse = adresse;
			this.nom = nom;
			this.prenom = prenom;
			this.barcode = barcode;
		}

		public Adherent (string id, string adresse, string nom, string prenom, string barcode, int id_dossard) {
			this.adresse = adresse;
			this.nom = nom;
			this.prenom = prenom;
			this.barcode = barcode;
			this.id_dossard = id_dossard;
		}

		public string getadresse () {return adresse;}
		public string getnom () {return nom;}
		public string getprenom () {return prenom;}
		public string getbarcode () {return barcode;}
		public int getid_dossard () {return id_dossard;}
	}
}

