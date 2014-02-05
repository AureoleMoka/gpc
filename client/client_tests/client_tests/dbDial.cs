using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using Mono.Security;
using gpcdb;
using Npgsql;

namespace gpcclient
{
    public class dbdial
    {
		public List<Participant> liste_participants { get; set; }
        List<Adherent> liste_adherents;
        NpgsqlConnection dbcon;
		Course course;

        public dbdial(string server, string port, string database, string user, string password)
        {
            dbcon = new NpgsqlConnection ("Server="   + server   + ";" +
                                          "Port="     + port     + ";" +
                                          "Database=" + database + ";" +
                                          "User Id="  + user     + ";" +
			                              "Password=" + password + ";" );

			dbcon.Open ();
            remplir_liste_adherents();
        }

        private void remplir_liste_adherents()
        {
			liste_adherents = new List<Adherent>();
            NpgsqlDataReader Data_adherents = readData ("adherent");

			while (Data_adherents.Read ()) {
					liste_adherents.Add (new Adherent (
						Convert.ToInt32 (Data_adherents [0]),
						Data_adherents [1].ToString (),
						Data_adherents [2].ToString (),
						Data_adherents [3].ToString (),
				    	Data_adherents [4].ToString ()
					));
			}
		}

		public int chercher_Adherent(string barcode) {
            foreach (Adherent A in liste_adherents)
                if (barcode == A.barcode)
                    return A.id;
            return enregistrer_nouveau("Inconnu", "Inconnu", "Inconnu", barcode);
        }

        public void update_Adherent(string adresse, string nom, string prenom, string barcode)
        {
            new NpgsqlCommand(
				String.Format(
					"UPDATE perfgraphs_adherent " +
            		"SET adresse = '{0}', nom = '{1}', prenom = '{2}' " +
            		"WHERE barcode = '{3}'", adresse, nom, prenom, barcode
				), dbcon
			).ExecuteNonQuery();

            remplir_liste_adherents();
        }

        public int enregistrer_nouveau(string adresse, string nom, string prenom, string barcode)
        {
            string parametres = "adresse={0},nom={1},prenom={2},barcode={3}";
            parametres = String.Format(parametres, adresse, nom, prenom, barcode);
			Adherent A = new Adherent (writeRow ("adherent", parametres), adresse, nom, prenom, barcode);

			liste_adherents.Add (A);
			return A.id;
        }

		public void enregistrer_course (string id_dossard, Participant P) {
			course.enregistrer_participant (id_dossard, P);
		}

		private int searchID(string table, string values) {
			return Convert.ToInt32 (
				new NpgsqlCommand (
					"SELECT id FROM perfgraphs_"
					+ table
					+ " WHERE "
					+ values
					, dbcon
				).ExecuteReader ()
			);
		}
		
		// Retourne l'id de la colonne insérée
        private int writeRow(string table, string values)
        {
            StringBuilder cols = new StringBuilder();
            StringBuilder keys = new StringBuilder();

            foreach (string v in values.Split(','))
            {
                cols.AppendFormat("{0}, "  , v.Split('=')[0]);
                keys.AppendFormat("'{0}', ", v.Split('=')[1]);
            }

            cols.Remove(cols.Length - 2, 2);
            keys.Remove(keys.Length - 2, 2);

            new NpgsqlCommand(
				"INSERT INTO perfgraphs_"
            	+ table
            	+ String.Format(" ({0}) VALUES ({1});"
            		, cols.ToString()
            		, keys.ToString()
            	), dbcon
			).ExecuteNonQuery();

			return searchID (table, values);
        }

        private NpgsqlDataReader readData (string table)
        {
            NpgsqlCommand command = new NpgsqlCommand("select * from perfgraphs_" + table, dbcon);
			return command.ExecuteReader();
        }

		private NpgsqlDataReader searchData (string table, string cmp) {
				StringBuilder query = new StringBuilder();

				foreach (string v in cmp.Split(';'))
					query.AppendFormat("{0}", v);

				NpgsqlCommand command = new NpgsqlCommand(String.Format ("select {0} from perfgraphs_", query) + table);
				return command.ExecuteReader();
			}

        public void printTable(string table) {
            NpgsqlDataReader dr = readData(table);

            while (dr.Read()) {
                for (int i = 0; i < dr.FieldCount; i++)
                    Console.Write("{0} \t", dr[i]);

                Console.WriteLine();
			}
        }
    }
}
