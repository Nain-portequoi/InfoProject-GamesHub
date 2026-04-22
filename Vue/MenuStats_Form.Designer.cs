namespace MenuStatsForm
{
    partial class MenuStats_Form
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
            this.GpbStats = new System.Windows.Forms.GroupBox();
            this.RdbShowRounds = new System.Windows.Forms.RadioButton();
            this.RdbShowGames = new System.Windows.Forms.RadioButton();
            this.RdbShowPlayers = new System.Windows.Forms.RadioButton();
            this.RichTxtStats = new System.Windows.Forms.RichTextBox();
            this.GpbStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.SaddleBrown;
            this.BtnBack.Location = new System.Drawing.Point(50, 100);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(292, 127);
            this.BtnBack.TabIndex = 4;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // GpbStats
            // 
            this.GpbStats.BackColor = System.Drawing.Color.Transparent;
            this.GpbStats.Controls.Add(this.RdbShowRounds);
            this.GpbStats.Controls.Add(this.RdbShowGames);
            this.GpbStats.Controls.Add(this.RdbShowPlayers);
            this.GpbStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpbStats.Location = new System.Drawing.Point(1306, 777);
            this.GpbStats.Name = "GpbStats";
            this.GpbStats.Size = new System.Drawing.Size(575, 268);
            this.GpbStats.TabIndex = 5;
            this.GpbStats.TabStop = false;
            this.GpbStats.Text = "Chose a stat to show";
            // 
            // RdbShowRounds
            // 
            this.RdbShowRounds.AutoSize = true;
            this.RdbShowRounds.Enabled = false;
            this.RdbShowRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbShowRounds.Location = new System.Drawing.Point(19, 177);
            this.RdbShowRounds.Name = "RdbShowRounds";
            this.RdbShowRounds.Size = new System.Drawing.Size(179, 46);
            this.RdbShowRounds.TabIndex = 2;
            this.RdbShowRounds.TabStop = true;
            this.RdbShowRounds.Text = "Rounds";
            this.RdbShowRounds.UseVisualStyleBackColor = true;
            this.RdbShowRounds.CheckedChanged += new System.EventHandler(this.RdbShowRounds_CheckedChanged);
            // 
            // RdbShowGames
            // 
            this.RdbShowGames.AutoSize = true;
            this.RdbShowGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbShowGames.Location = new System.Drawing.Point(19, 125);
            this.RdbShowGames.Name = "RdbShowGames";
            this.RdbShowGames.Size = new System.Drawing.Size(168, 46);
            this.RdbShowGames.TabIndex = 1;
            this.RdbShowGames.TabStop = true;
            this.RdbShowGames.Text = "Games";
            this.RdbShowGames.UseVisualStyleBackColor = true;
            this.RdbShowGames.CheckedChanged += new System.EventHandler(this.RdbShowGames_CheckedChanged);
            // 
            // RdbShowPlayers
            // 
            this.RdbShowPlayers.AutoSize = true;
            this.RdbShowPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbShowPlayers.Location = new System.Drawing.Point(19, 73);
            this.RdbShowPlayers.Name = "RdbShowPlayers";
            this.RdbShowPlayers.Size = new System.Drawing.Size(175, 46);
            this.RdbShowPlayers.TabIndex = 0;
            this.RdbShowPlayers.TabStop = true;
            this.RdbShowPlayers.Text = "Players";
            this.RdbShowPlayers.UseVisualStyleBackColor = true;
            this.RdbShowPlayers.CheckedChanged += new System.EventHandler(this.RdbShowPlayers_CheckedChanged);
            // 
            // RichTxtStats
            // 
            this.RichTxtStats.BackColor = System.Drawing.Color.Bisque;
            this.RichTxtStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTxtStats.Location = new System.Drawing.Point(684, 869);
            this.RichTxtStats.Name = "RichTxtStats";
            this.RichTxtStats.Size = new System.Drawing.Size(1728, 479);
            this.RichTxtStats.TabIndex = 6;
            this.RichTxtStats.Text = "";
            this.RichTxtStats.Visible = false;
            // 
            // MenuStats_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfoProject_GamesHub.Properties.Resources.Stats_Menu___Image_GamesHub___Projet_d_info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.GpbStats);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.RichTxtStats);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MenuStats_Form";
            this.Size = new System.Drawing.Size(2140, 1360);
            this.GpbStats.ResumeLayout(false);
            this.GpbStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.GroupBox GpbStats;
        private System.Windows.Forms.RadioButton RdbShowPlayers;
        private System.Windows.Forms.RadioButton RdbShowRounds;
        private System.Windows.Forms.RadioButton RdbShowGames;
        private System.Windows.Forms.RichTextBox RichTxtStats;
    }
}
