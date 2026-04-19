namespace MenuCreatePlayer
{
    partial class CreatePlayer_Form
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlayerCreation = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.TxtPseudo = new System.Windows.Forms.TextBox();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.BtnSaveInformation = new System.Windows.Forms.Button();
            this.lblRequired = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerCreation
            // 
            this.lblPlayerCreation.AutoSize = true;
            this.lblPlayerCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerCreation.Location = new System.Drawing.Point(35, 156);
            this.lblPlayerCreation.Name = "lblPlayerCreation";
            this.lblPlayerCreation.Size = new System.Drawing.Size(835, 126);
            this.lblPlayerCreation.TabIndex = 1;
            this.lblPlayerCreation.Text = "Player Creation";
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(1737, 83);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(292, 127);
            this.BtnBack.TabIndex = 3;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPseudo.Location = new System.Drawing.Point(119, 343);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(233, 59);
            this.lblPseudo.TabIndex = 5;
            this.lblPseudo.Text = "Pseudo :";
            // 
            // TxtPseudo
            // 
            this.TxtPseudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPseudo.Location = new System.Drawing.Point(445, 343);
            this.TxtPseudo.Name = "TxtPseudo";
            this.TxtPseudo.Size = new System.Drawing.Size(287, 65);
            this.TxtPseudo.TabIndex = 6;
            this.TxtPseudo.TextChanged += new System.EventHandler(this.TxtPseudo_TextChanged);
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(445, 451);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(287, 65);
            this.TxtFirstName.TabIndex = 8;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(119, 451);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(313, 59);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "First Name :";
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(445, 557);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(287, 65);
            this.TxtLastName.TabIndex = 10;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(119, 557);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(309, 59);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Last Name :";
            // 
            // BtnSaveInformation
            // 
            this.BtnSaveInformation.Enabled = false;
            this.BtnSaveInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveInformation.Location = new System.Drawing.Point(129, 758);
            this.BtnSaveInformation.Name = "BtnSaveInformation";
            this.BtnSaveInformation.Size = new System.Drawing.Size(603, 127);
            this.BtnSaveInformation.TabIndex = 11;
            this.BtnSaveInformation.Text = "Save Information";
            this.BtnSaveInformation.UseVisualStyleBackColor = true;
            this.BtnSaveInformation.Click += new System.EventHandler(this.BtnSaveInformation_Click);
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRequired.Location = new System.Drawing.Point(738, 343);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(274, 59);
            this.lblRequired.TabIndex = 12;
            this.lblRequired.Text = "* Required";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(738, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 59);
            this.label1.TabIndex = 13;
            this.label1.Text = "(Optionnal)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(738, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 59);
            this.label2.TabIndex = 14;
            this.label2.Text = "(Optionnal)";
            // 
            // CreatePlayer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.BtnSaveInformation);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.TxtPseudo);
            this.Controls.Add(this.lblPseudo);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.lblPlayerCreation);
            this.Name = "CreatePlayer_Form";
            this.Size = new System.Drawing.Size(2140, 1360);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerCreation;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.TextBox TxtPseudo;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button BtnSaveInformation;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
