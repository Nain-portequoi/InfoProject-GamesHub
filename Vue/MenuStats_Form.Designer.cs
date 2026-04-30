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
            this.components = new System.ComponentModel.Container();
            this.BtnBack = new System.Windows.Forms.Button();
            this.GpbStats = new System.Windows.Forms.GroupBox();
            this.RdbShowRounds = new System.Windows.Forms.RadioButton();
            this.RdbShowGames = new System.Windows.Forms.RadioButton();
            this.RdbShowPlayers = new System.Windows.Forms.RadioButton();
            this.RichTxtStats = new System.Windows.Forms.RichTextBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblSearch = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pctSearch = new System.Windows.Forms.PictureBox();
            this.GpbStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.SaddleBrown;
            this.BtnBack.Location = new System.Drawing.Point(36, 67);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(212, 85);
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
            this.GpbStats.Location = new System.Drawing.Point(950, 518);
            this.GpbStats.Margin = new System.Windows.Forms.Padding(2);
            this.GpbStats.Name = "GpbStats";
            this.GpbStats.Padding = new System.Windows.Forms.Padding(2);
            this.GpbStats.Size = new System.Drawing.Size(418, 179);
            this.GpbStats.TabIndex = 5;
            this.GpbStats.TabStop = false;
            this.GpbStats.Text = "Chose a stat to show";
            // 
            // RdbShowRounds
            // 
            this.RdbShowRounds.AutoSize = true;
            this.RdbShowRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbShowRounds.Location = new System.Drawing.Point(14, 118);
            this.RdbShowRounds.Margin = new System.Windows.Forms.Padding(2);
            this.RdbShowRounds.Name = "RdbShowRounds";
            this.RdbShowRounds.Size = new System.Drawing.Size(135, 35);
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
            this.RdbShowGames.Location = new System.Drawing.Point(14, 83);
            this.RdbShowGames.Margin = new System.Windows.Forms.Padding(2);
            this.RdbShowGames.Name = "RdbShowGames";
            this.RdbShowGames.Size = new System.Drawing.Size(127, 35);
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
            this.RdbShowPlayers.Location = new System.Drawing.Point(14, 49);
            this.RdbShowPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.RdbShowPlayers.Name = "RdbShowPlayers";
            this.RdbShowPlayers.Size = new System.Drawing.Size(133, 35);
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
            this.RichTxtStats.Location = new System.Drawing.Point(497, 579);
            this.RichTxtStats.Margin = new System.Windows.Forms.Padding(2);
            this.RichTxtStats.Name = "RichTxtStats";
            this.RichTxtStats.Size = new System.Drawing.Size(1258, 321);
            this.RichTxtStats.TabIndex = 6;
            this.RichTxtStats.Text = "";
            this.RichTxtStats.Visible = false;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(1400, 421);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchBox.Multiline = true;
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(355, 111);
            this.txtSearchBox.TabIndex = 7;
            this.txtSearchBox.Visible = false;
            this.txtSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchBox_KeyPress);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(1394, 387);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(109, 36);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Search";
            this.lblSearch.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pctSearch
            // 
            this.pctSearch.BackgroundImage = global::InfoProject_GamesHub.Properties.Resources.Icone_de_Recherche___Projet_Info___GamesHub;
            this.pctSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctSearch.Location = new System.Drawing.Point(1509, 379);
            this.pctSearch.Margin = new System.Windows.Forms.Padding(2);
            this.pctSearch.Name = "pctSearch";
            this.pctSearch.Size = new System.Drawing.Size(41, 39);
            this.pctSearch.TabIndex = 9;
            this.pctSearch.TabStop = false;
            this.pctSearch.Visible = false;
            // 
            // MenuStats_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InfoProject_GamesHub.Properties.Resources.Stats_Menu___Image_GamesHub___Projet_d_info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pctSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.GpbStats);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.RichTxtStats);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuStats_Form";
            this.Size = new System.Drawing.Size(1556, 907);
            this.GpbStats.ResumeLayout(false);
            this.GpbStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.GroupBox GpbStats;
        private System.Windows.Forms.RadioButton RdbShowPlayers;
        private System.Windows.Forms.RadioButton RdbShowRounds;
        private System.Windows.Forms.RadioButton RdbShowGames;
        private System.Windows.Forms.RichTextBox RichTxtStats;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pctSearch;
    }
}
