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
            this.lblGameName.BackColor = System.Drawing.Color.White;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(392, 86);
            this.lblGameName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(561, 108);
            this.lblGameName.TabIndex = 0;
            this.lblGameName.Text = "GameName";
            // 
            // BtnNewGame
            // 
            this.BtnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewGame.Location = new System.Drawing.Point(118, 386);
            this.BtnNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnNewGame.Name = "BtnNewGame";
            this.BtnNewGame.Size = new System.Drawing.Size(203, 92);
            this.BtnNewGame.TabIndex = 1;
            this.BtnNewGame.Text = "New Game";
            this.BtnNewGame.UseVisualStyleBackColor = true;
            this.BtnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // BtnStats
            // 
            this.BtnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStats.Location = new System.Drawing.Point(365, 386);
            this.BtnStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnStats.Name = "BtnStats";
            this.BtnStats.Size = new System.Drawing.Size(203, 92);
            this.BtnStats.TabIndex = 2;
            this.BtnStats.Text = "Stats";
            this.BtnStats.UseVisualStyleBackColor = true;
            this.BtnStats.Click += new System.EventHandler(this.BtnStats_Click);
            // 
            // BtnCreatePlayer
            // 
            this.BtnCreatePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreatePlayer.Location = new System.Drawing.Point(607, 386);
            this.BtnCreatePlayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnCreatePlayer.Name = "BtnCreatePlayer";
            this.BtnCreatePlayer.Size = new System.Drawing.Size(203, 92);
            this.BtnCreatePlayer.TabIndex = 3;
            this.BtnCreatePlayer.Text = "Create Player";
            this.BtnCreatePlayer.UseVisualStyleBackColor = true;
            this.BtnCreatePlayer.Click += new System.EventHandler(this.BtnCreatePlayer_Click);
            // 
            // BtnLeave
            // 
            this.BtnLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLeave.Location = new System.Drawing.Point(854, 386);
            this.BtnLeave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnLeave.Name = "BtnLeave";
            this.BtnLeave.Size = new System.Drawing.Size(203, 92);
            this.BtnLeave.TabIndex = 4;
            this.BtnLeave.Text = "Leave";
            this.BtnLeave.UseVisualStyleBackColor = true;
            this.BtnLeave.Click += new System.EventHandler(this.BtnLeave_Click);
            // 
            // PnlHost
            // 
            this.PnlHost.Location = new System.Drawing.Point(2, 2);
            this.PnlHost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PnlHost.Name = "PnlHost";
            this.PnlHost.Size = new System.Drawing.Size(109, 54);
            this.PnlHost.TabIndex = 5;
            this.PnlHost.Visible = false;
            // 
            // MainMenu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.BackgroundImage = global::InfoProject_GamesHub.Properties.Resources.Menu_PrincipalImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1154, 645);
            this.Controls.Add(this.PnlHost);
            this.Controls.Add(this.BtnLeave);
            this.Controls.Add(this.BtnCreatePlayer);
            this.Controls.Add(this.BtnStats);
            this.Controls.Add(this.BtnNewGame);
            this.Controls.Add(this.lblGameName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        public System.Windows.Forms.Panel PnlHost;
    }
}

