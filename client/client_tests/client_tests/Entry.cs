using System;
using gpcdb;
using gpcclient;

namespace client_tests
{
	static public class Entry
	{
		static public void generate_random () {
			dbdial db = new dbdial ("mokablog.fr", "5432", "gpcdb", "gpcdb-admin", "Zrd[YuTKL7\"n2");

			Console.WriteLine ("nom:");
			string nom = Console.ReadLine ();

			Console.WriteLine ("prenom:");
			string prenom = Console.ReadLine ();

			Console.WriteLine ("adresse:");
			string adresse = Console.ReadLine ();

			//Adherent created = db.enregistrer_nouveau (adresse, nom, prenom);
		}

		static public void Main() {
			dbdial db = new dbdial ("192.168.1.12", "5432", "gpcdb", "gpcdb-admin", "Zrd[YuTKL7\"n2");
			db.printTable ("adherent");
			Console.WriteLine (db.chercher_Adherent ("0900898"));
		}
	}
}

