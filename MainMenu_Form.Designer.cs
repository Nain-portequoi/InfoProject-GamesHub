namespace MainMenuForm
{
    partial class MainMenu_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGameName = new System.Windows.Forms.Label();
            this.BtnNewGame = new System.Windows.Forms.Button();
            this.BtnStats = new System.Windows.Forms.Button();
            this.BtnCreatePlayer = new System.Windows.Forms.Button();
            this.BtnLeave = new System.Windows.Forms.Button();
            this.PnlHost = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(546, 193);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(984, 190);
            this.lblGameName.TabIndex = 0;
            this.lblGameName.Text = "GameName";
            // 
            // BtnNewGame
            // 
            this.BtnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewGame.Location = new System.Drawing.Point(216, 712);
            this.BtnNewGame.Name = "BtnNewGame";
            this.BtnNewGame.Size = new System.Drawing.Size(372, 170);
            this.BtnNewGame.TabIndex = 1;
            this.BtnNewGame.Text = "New Game";
            this.BtnNewGame.UseVisualStyleBackColor = true;
            this.BtnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // BtnStats
            // 
            this.BtnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStats.Location = new System.Drawing.Point(670, 712);
            this.BtnStats.Name = "BtnStats";
            this.BtnStats.Size = new System.Drawing.Size(372, 170);
            this.BtnStats.TabIndex = 2;
            this.BtnStats.Text = "Stats";
            this.BtnStats.UseVisualStyleBackColor = true;
            // 
            // BtnCreatePlayer
            // 
            this.BtnCreatePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreatePlayer.Location = new System.Drawing.Point(1112, 712);
            this.BtnCreatePlayer.Name = "BtnCreatePlayer";
            this.BtnCreatePlayer.Size = new System.Drawing.Size(372, 170);
            this.BtnCreatePlayer.TabIndex = 3;
            this.BtnCreatePlayer.Text = "Create Player";
            this.BtnCreatePlayer.UseVisualStyleBackColor = true;
            // 
            // BtnLeave
            // 
            this.BtnLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLeave.Location = new System.Drawing.Point(1565, 712);
            this.BtnLeave.Name = "BtnLeave";
            this.BtnLeave.Size = new System.Drawing.Size(372, 170);
            this.BtnLeave.TabIndex = 4;
            this.BtnLeave.Text = "Leave";
            this.BtnLeave.UseVisualStyleBackColor = true;
            // 
            // PnlHost
            // 
            this.PnlHost.Location = new System.Drawing.Point(3, 3);
            this.PnlHost.Name = "PnlHost";
            this.PnlHost.Size = new System.Drawing.Size(200, 100);
            this.PnlHost.TabIndex = 5;
            this.PnlHost.Visible = false;
            // 
            // MainMenu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(2119, 1296);
            this.Controls.Add(this.PnlHost);
            this.Controls.Add(this.BtnLeave);
            this.Controls.Add(this.BtnCreatePlayer);
            this.Controls.Add(this.BtnStats);
            this.Controls.Add(this.BtnNewGame);
            this.Controls.Add(this.lblGameName);
            this.Name = "MainMenu_Form";
            this.Text = "MainMenu_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Button BtnNewGame;
        private System.Windows.Forms.Button BtnStats;
        private System.Windows.Forms.Button BtnCreatePlayer;
        private System.Windows.Forms.Button BtnLeave;
        private System.Windows.Forms.Panel PnlHost;
    }
}

