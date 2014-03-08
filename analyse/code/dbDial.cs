public dbdial(string server, string port, string database, string user, string password) {

  dbcon = new NpgsqlConnection(
    "Server="   + server   + ";" +
    "Port="     + port     + ";" +
    "Database=" + database + ";" +
    "User Id="  + user     + ";" +
    "Password=" + password + ";Pooling=False"
  );

  liste_adherents = new List<Adherent>();
  remplir_liste_adherents();
}
