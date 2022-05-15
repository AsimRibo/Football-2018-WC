
namespace WinFormsDesign.UserControls
{
    partial class GamesUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamesUC));
            this.pictureBoxHome = new System.Windows.Forms.PictureBox();
            this.pictureBoxAway = new System.Windows.Forms.PictureBox();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbHomeTeam = new System.Windows.Forms.Label();
            this.lbAwayTeam = new System.Windows.Forms.Label();
            this.lbHomeScore = new System.Windows.Forms.Label();
            this.lbAwayScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbNumberOfFans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAway)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHome
            // 
            resources.ApplyResources(this.pictureBoxHome, "pictureBoxHome");
            this.pictureBoxHome.Name = "pictureBoxHome";
            this.pictureBoxHome.TabStop = false;
            // 
            // pictureBoxAway
            // 
            resources.ApplyResources(this.pictureBoxAway, "pictureBoxAway");
            this.pictureBoxAway.Name = "pictureBoxAway";
            this.pictureBoxAway.TabStop = false;
            // 
            // lbLocation
            // 
            resources.ApplyResources(this.lbLocation, "lbLocation");
            this.lbLocation.Name = "lbLocation";
            // 
            // lbHomeTeam
            // 
            resources.ApplyResources(this.lbHomeTeam, "lbHomeTeam");
            this.lbHomeTeam.Name = "lbHomeTeam";
            // 
            // lbAwayTeam
            // 
            resources.ApplyResources(this.lbAwayTeam, "lbAwayTeam");
            this.lbAwayTeam.Name = "lbAwayTeam";
            // 
            // lbHomeScore
            // 
            resources.ApplyResources(this.lbHomeScore, "lbHomeScore");
            this.lbHomeScore.Name = "lbHomeScore";
            // 
            // lbAwayScore
            // 
            resources.ApplyResources(this.lbAwayScore, "lbAwayScore");
            this.lbAwayScore.Name = "lbAwayScore";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lbNumberOfFans
            // 
            resources.ApplyResources(this.lbNumberOfFans, "lbNumberOfFans");
            this.lbNumberOfFans.Name = "lbNumberOfFans";
            // 
            // GamesUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbNumberOfFans);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAwayScore);
            this.Controls.Add(this.lbHomeScore);
            this.Controls.Add(this.lbAwayTeam);
            this.Controls.Add(this.lbHomeTeam);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.pictureBoxAway);
            this.Controls.Add(this.pictureBoxHome);
            this.Name = "GamesUC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAway)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHome;
        private System.Windows.Forms.PictureBox pictureBoxAway;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbHomeTeam;
        private System.Windows.Forms.Label lbAwayTeam;
        private System.Windows.Forms.Label lbHomeScore;
        private System.Windows.Forms.Label lbAwayScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbNumberOfFans;
    }
}
