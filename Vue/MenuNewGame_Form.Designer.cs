namespace NewGameForm
{
    partial class MenuNewGame_Form
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
            this.BtnBack = new System.Windows.Forms.Button();
            this.CcbPlayer1 = new System.Windows.Forms.ComboBox();
            this.lblSelectPlayer1 = new System.Windows.Forms.Label();
            this.lblSelectPlayer2 = new System.Windows.Forms.Label();
            this.CcbPlayer2 = new System.Windows.Forms.ComboBox();
            this.lblSelectGame = new System.Windows.Forms.Label();
            this.BtnPictionary = new System.Windows.Forms.Button();
            this.BtnBlackJack = new System.Windows.Forms.Button();
            this.PnlMenuNewGame = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(1775, 85);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(292, 127);
            this.BtnBack.TabIndex = 2;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // CcbPlayer1
            // 
            this.CcbPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CcbPlayer1.FormattingEnabled = true;
            this.CcbPlayer1.Location = new System.Drawing.Point(310, 382);
            this.CcbPlayer1.Name = "CcbPlayer1";
            this.CcbPlayer1.Size = new System.Drawing.Size(371, 67);
            this.CcbPlayer1.TabIndex = 3;
            this.CcbPlayer1.SelectedIndexChanged += new System.EventHandler(this.CcbPlayer1_SelectedIndexChanged);
            // 
            // lblSelectPlayer1
            // 
            this.lblSelectPlayer1.AutoSize = true;
            this.lblSelectPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPlayer1.Location = new System.Drawing.Point(300, 308);
            this.lblSelectPlayer1.Name = "lblSelectPlayer1";
            this.lblSelectPlayer1.Size = new System.Drawing.Size(381, 59);
            this.lblSelectPlayer1.TabIndex = 4;
            this.lblSelectPlayer1.Text = "Select Player 1";
            // 
            // lblSelectPlayer2
            // 
            this.lblSelectPlayer2.AutoSize = true;
            this.lblSelectPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPlayer2.Location = new System.Drawing.Point(1212, 308);
            this.lblSelectPlayer2.Name = "lblSelectPlayer2";
            this.lblSelectPlayer2.Size = new System.Drawing.Size(381, 59);
            this.lblSelectPlayer2.TabIndex = 6;
            this.lblSelectPlayer2.Text = "Select Player 2";
            // 
            // CcbPlayer2
            // 
            this.CcbPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CcbPlayer2.FormattingEnabled = true;
            this.CcbPlayer2.Location = new System.Drawing.Point(1222, 382);
            this.CcbPlayer2.Name = "CcbPlayer2";
            this.CcbPlayer2.Size = new System.Drawing.Size(371, 67);
            this.CcbPlayer2.TabIndex = 5;
            this.CcbPlayer2.SelectedIndexChanged += new System.EventHandler(this.CcbPlayer2_SelectedIndexChanged);
            // 
            // lblSelectGame
            // 
            this.lblSelectGame.AutoSize = true;
            this.lblSelectGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectGame.Location = new System.Drawing.Point(805, 708);
            this.lblSelectGame.Name = "lblSelectGame";
            this.lblSelectGame.Size = new System.Drawing.Size(359, 59);
            this.lblSelectGame.TabIndex = 7;
            this.lblSelectGame.Text = "Select Game :";
            // 
            // BtnPictionary
            // 
            this.BtnPictionary.Enabled = false;
            this.BtnPictionary.Location = new System.Drawing.Point(387, 813);
            this.BtnPictionary.Name = "BtnPictionary";
            this.BtnPictionary.Size = new System.Drawing.Size(349, 391);
            this.BtnPictionary.TabIndex = 8;
            this.BtnPictionary.Text = "Game1";
            this.BtnPictionary.UseVisualStyleBackColor = true;
            this.BtnPictionary.Click += new System.EventHandler(this.BtnPictionary_Click);
            // 
            // BtnBlackJack
            // 
            this.BtnBlackJack.Enabled = false;
            this.BtnBlackJack.Location = new System.Drawing.Point(1244, 813);
            this.BtnBlackJack.Name = "BtnBlackJack";
            this.BtnBlackJack.Size = new System.Drawing.Size(349, 391);
            this.BtnBlackJack.TabIndex = 9;
            this.BtnBlackJack.Text = "Game2";
            this.BtnBlackJack.UseVisualStyleBackColor = true;
            this.BtnBlackJack.Click += new System.EventHandler(this.BtnBlackJack_Click);
            // 
            // PnlMenuNewGame
            // 
            this.PnlMenuNewGame.Location = new System.Drawing.Point(0, 0);
            this.PnlMenuNewGame.Name = "PnlMenuNewGame";
            this.PnlMenuNewGame.Size = new System.Drawing.Size(200, 100);
            this.PnlMenuNewGame.TabIndex = 10;
            this.PnlMenuNewGame.Visible = false;
            // 
            // MenuNewGame_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.Controls.Add(this.PnlMenuNewGame);
            this.Controls.Add(this.BtnBlackJack);
            this.Controls.Add(this.BtnPictionary);
            this.Controls.Add(this.lblSelectGame);
            this.Controls.Add(this.lblSelectPlayer2);
            this.Controls.Add(this.CcbPlayer2);
            this.Controls.Add(this.lblSelectPlayer1);
            this.Controls.Add(this.CcbPlayer1);
            this.Controls.Add(this.BtnBack);
            this.Name = "MenuNewGame_Form";
            this.Size = new System.Drawing.Size(2140, 1360);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.ComboBox CcbPlayer1;
        private System.Windows.Forms.Label lblSelectPlayer1;
        private System.Windows.Forms.Label lblSelectPlayer2;
        private System.Windows.Forms.ComboBox CcbPlayer2;
        private System.Windows.Forms.Label lblSelectGame;
        private System.Windows.Forms.Button BtnPictionary;
        private System.Windows.Forms.Button BtnBlackJack;
        public System.Windows.Forms.Panel PnlMenuNewGame;
    }
}
