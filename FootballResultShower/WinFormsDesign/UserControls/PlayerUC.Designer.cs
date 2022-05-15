
namespace WinFormsDesign.UserControls
{
    partial class PlayerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbFavorite = new System.Windows.Forms.Label();
            this.lbShirtNumber = new System.Windows.Forms.Label();
            this.lbCaptain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPlayer
            // 
            resources.ApplyResources(this.pictureBoxPlayer, "pictureBoxPlayer");
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.TabStop = false;
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbPosition
            // 
            resources.ApplyResources(this.lbPosition, "lbPosition");
            this.lbPosition.Name = "lbPosition";
            // 
            // lbFavorite
            // 
            resources.ApplyResources(this.lbFavorite, "lbFavorite");
            this.lbFavorite.Name = "lbFavorite";
            // 
            // lbShirtNumber
            // 
            resources.ApplyResources(this.lbShirtNumber, "lbShirtNumber");
            this.lbShirtNumber.Name = "lbShirtNumber";
            // 
            // lbCaptain
            // 
            resources.ApplyResources(this.lbCaptain, "lbCaptain");
            this.lbCaptain.Name = "lbCaptain";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PlayerUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCaptain);
            this.Controls.Add(this.lbShirtNumber);
            this.Controls.Add(this.lbFavorite);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBoxPlayer);
            this.Name = "PlayerUC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbFavorite;
        private System.Windows.Forms.Label lbShirtNumber;
        private System.Windows.Forms.Label lbCaptain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
    }
}
