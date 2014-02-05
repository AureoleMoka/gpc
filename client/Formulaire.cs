using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gpcclient {
    public partial class Formulaire : Form {
        dbdial DB;

        public Formulaire () {
            InitializeComponent();

            //CodeReader.Open();
            CheckForIllegalCrossThreadCalls = false;
        }

//        private void CodeReader_DataReceived (object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
//            // on enleve le caractere '\r' à la fin du code barre
//            string barcode = CodeReader.ReadLine();
//            barcode = barcode.Remove (barcode.Length - 1);
//
//            nameBox.Text      = DB.chercher_Adherent (barcode).getnom();
//            firstnameBox.Text = DB.chercher_Adherent (barcode).getprenom();
//            adressBox.Text    = DB.chercher_Adherent (barcode).getadresse();
//        }

        private void connButton_Click(object sender, EventArgs e) {
            BDtextbox.Text = "Connexion en cours…";
            try {
                DB = new dbdial("192.168.1.12", "5432", "gpcdb", "gpcdb-admin", "Zrd[YuTKL7\"n2");
                BDtextbox.Text = "Connexion établie.";
            }

            catch (Npgsql.NpgsqlException) {
                BDtextbox.Text = "Connexion échouée.";
            }
        }

    }
}
