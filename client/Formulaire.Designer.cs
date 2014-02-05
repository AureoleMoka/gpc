namespace gpcclient
{
    partial class Formulaire
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.firstnameBox = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.Label();
            this.adressBox = new System.Windows.Forms.TextBox();
            this.adress = new System.Windows.Forms.Label();
            //this.CodeReader = new System.IO.Ports.SerialPort(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.connButton = new System.Windows.Forms.Button();
            this.BDtextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(78, 72);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(182, 20);
            this.nameBox.TabIndex = 2;
            // 
            // firstnameBox
            // 
            this.firstnameBox.Location = new System.Drawing.Point(78, 98);
            this.firstnameBox.Name = "firstnameBox";
            this.firstnameBox.Size = new System.Drawing.Size(182, 20);
            this.firstnameBox.TabIndex = 3;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.name.Location = new System.Drawing.Point(12, 72);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(37, 17);
            this.name.TabIndex = 4;
            this.name.Text = "Nom";
            // 
            // firstname
            // 
            this.firstname.AutoSize = true;
            this.firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.firstname.Location = new System.Drawing.Point(12, 98);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(57, 17);
            this.firstname.TabIndex = 5;
            this.firstname.Text = "Prénom";
            // 
            // adressBox
            // 
            this.adressBox.Location = new System.Drawing.Point(78, 125);
            this.adressBox.Name = "adressBox";
            this.adressBox.Size = new System.Drawing.Size(182, 20);
            this.adressBox.TabIndex = 6;
            // 
            // adress
            // 
            this.adress.AutoSize = true;
            this.adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.adress.Location = new System.Drawing.Point(12, 125);
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(60, 17);
            this.adress.TabIndex = 7;
            this.adress.Text = "Adresse";
            // 
            // CodeReader
            // 
//            this.CodeReader.DataBits = 7;
//            this.CodeReader.DiscardNull = true;
//            this.CodeReader.Parity = System.IO.Ports.Parity.Space;
//            this.CodeReader.PortName = "COM5";
//            this.CodeReader.StopBits = System.IO.Ports.StopBits.Two;
//            this.CodeReader.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CodeReader_DataReceived);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(56, 157);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(141, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Enregistrer courreur";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // connButton
            // 
            this.connButton.Location = new System.Drawing.Point(56, 12);
            this.connButton.Name = "connButton";
            this.connButton.Size = new System.Drawing.Size(141, 23);
            this.connButton.TabIndex = 9;
            this.connButton.Text = "Connexion à la BD";
            this.connButton.UseVisualStyleBackColor = true;
            this.connButton.Click += new System.EventHandler(this.connButton_Click);
            // 
            // BDtextbox
            // 
            this.BDtextbox.Location = new System.Drawing.Point(78, 41);
            this.BDtextbox.Name = "BDtextbox";
            this.BDtextbox.ReadOnly = true;
            this.BDtextbox.Size = new System.Drawing.Size(100, 20);
            this.BDtextbox.TabIndex = 10;
            // 
            // IdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 207);
            this.Controls.Add(this.BDtextbox);
            this.Controls.Add(this.connButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.adressBox);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.firstnameBox);
            this.Controls.Add(this.nameBox);
            this.Name = "IdForm";
            this.Text = "Formulaire d\'enregistrement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox firstnameBox;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label firstname;
        private System.Windows.Forms.TextBox adressBox;
        private System.Windows.Forms.Label adress;
        //private System.IO.Ports.SerialPort CodeReader;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button connButton;
        private System.Windows.Forms.TextBox BDtextbox;

    }
}

