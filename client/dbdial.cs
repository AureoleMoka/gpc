using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using System.Security;
using Mono.Security;
using Npgsql;

namespace gpcclient
{

    public class dbdial
    {
        List<Adherent> liste_adherents;
        NpgsqlConnection dbcon;

        public dbdial(string server, string port, string database, string user, string password)
        {
            dbcon = new NpgsqlConnection("Server=" + server + ";" +
                                          "Port=" + port + ";" +
                                          "Database=" + database + ";" +
                                          "User Id=" + user + ";" +
                                          "Password=" + password + ";Pooling=False");

            liste_adherents = new List<Adherent>();
            remplir_liste_adherents();
        }

        private void remplir_liste_adherents()
        {
            NpgsqlDataReader Data_adherents = readData("adherent");

            while (Data_adherents.Read())
                liste_adherents.Add(new Adherent(Data_adherents[0].ToString(),
                                                 Data_adherents[1].ToString(),
                                                 Data_adherents[2].ToString(),
                                                 Data_adherents[3].ToString()));



        }

        public Adherent chercher_Adherent(string barcode)
        {
            foreach (Adherent A in liste_adherents)
                if (barcode == A.getbarcode())
                    return A;
            return enregistrer_nouveau("Inconnu", "Inconnu", "Inconnu", barcode);
        }

        public void update_Adherent(string adresse, string nom, string prenom, string barcode)
        {
            dbcon.Open();

            new NpgsqlCommand(String.Format("UPDATE perfgraphs_adherent " +
            "SET adresse = '{0}', nom = '{1}', prenom = '{2}' " +
            "WHERE barcode = '{3}'", adresse, nom, prenom, barcode), dbcon).ExecuteNonQuery();

            dbcon.Close();
            remplir_liste_adherents();
        }

        public Adherent enregistrer_nouveau(string adresse, string nom, string prenom, string barcode)
        {
            Adherent A = new Adherent(adresse, nom, prenom, barcode);

            string parametres = "adresse={0};nom={1};prenom={2};barcode={3}";
            parametres = String.Format(parametres, adresse, nom, prenom, barcode);

            writeRow("adherent", parametres);
            liste_adherents.Add(A);
            return A;
        }

        private void writeRow(string table, string values)
        {
            dbcon.Open();

            StringBuilder cols = new StringBuilder();
            StringBuilder keys = new StringBuilder();

            foreach (string v in values.Split(';'))
            {
                cols.AppendFormat("{0}, ", v.Split('=')[0]);
                keys.AppendFormat("'{0}', ", v.Split('=')[1]);
            }

            cols.Remove(cols.Length - 2, 2);
            keys.Remove(keys.Length - 2, 2);

            new NpgsqlCommand("INSERT INTO perfgraphs_"
                              + table
                              + String.Format(" ({0}) VALUES ({1});"
                                , cols.ToString()
                                , keys.ToString()
                              ), dbcon).ExecuteNonQuery();

            dbcon.Close();
        }

        private NpgsqlDataReader readData(string table)
        {
            dbcon.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from perfgraphs_" + table, dbcon);

            NpgsqlDataReader D = command.ExecuteReader();
            dbcon.Close();

            return D;
        }

        public void printTable(string table)
        {
            NpgsqlDataReader dr = readData(table);
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                    Console.Write("{0} \t", dr[i]);

                Console.WriteLine();
            }
        }
    }
}
