
namespace WinFormsDesign
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabMainForm = new System.Windows.Forms.TabControl();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.lbTeamNameTab1 = new System.Windows.Forms.Label();
            this.lbFavoritePlayers = new System.Windows.Forms.Label();
            this.lbAllPlayers = new System.Windows.Forms.Label();
            this.flowPnlFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPnlAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabRankedPlayers = new System.Windows.Forms.TabPage();
            this.btnPrintCards = new System.Windows.Forms.Button();
            this.btnPrintGoals = new System.Windows.Forms.Button();
            this.lbTeamNameTab2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPnlGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankedGames = new System.Windows.Forms.TabPage();
            this.btnPrintGames = new System.Windows.Forms.Button();
            this.lbTeamNameTab3 = new System.Windows.Forms.Label();
            this.flowLayoutPnlGames = new System.Windows.Forms.FlowLayoutPanel();
            this.printPreviewDialogGoals = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentGoals = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogCards = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentCards = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogGames = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumentGames = new System.Drawing.Printing.PrintDocument();
            this.cmsEditPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changePlayerPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemContact = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMainForm.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabRankedPlayers.SuspendLayout();
            this.tabPageRankedGames.SuspendLayout();
            this.cmsEditPlayer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainForm
            // 
            resources.ApplyResources(this.tabMainForm, "tabMainForm");
            this.tabMainForm.Controls.Add(this.tabPlayers);
            this.tabMainForm.Controls.Add(this.tabRankedPlayers);
            this.tabMainForm.Controls.Add(this.tabPageRankedGames);
            this.tabMainForm.Name = "tabMainForm";
            this.tabMainForm.SelectedIndex = 0;
            this.tabMainForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabMainForm_KeyDown);
            // 
            // tabPlayers
            // 
            resources.ApplyResources(this.tabPlayers, "tabPlayers");
            this.tabPlayers.Controls.Add(this.lbTeamNameTab1);
            this.tabPlayers.Controls.Add(this.lbFavoritePlayers);
            this.tabPlayers.Controls.Add(this.lbAllPlayers);
            this.tabPlayers.Controls.Add(this.flowPnlFavoritePlayers);
            this.tabPlayers.Controls.Add(this.flowPnlAllPlayers);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.UseVisualStyleBackColor = true;
            this.tabPlayers.Enter += new System.EventHandler(this.tabPlayers_Enter);
            // 
            // lbTeamNameTab1
            // 
            resources.ApplyResources(this.lbTeamNameTab1, "lbTeamNameTab1");
            this.lbTeamNameTab1.Name = "lbTeamNameTab1";
            // 
            // lbFavoritePlayers
            // 
            resources.ApplyResources(this.lbFavoritePlayers, "lbFavoritePlayers");
            this.lbFavoritePlayers.Name = "lbFavoritePlayers";
            // 
            // lbAllPlayers
            // 
            resources.ApplyResources(this.lbAllPlayers, "lbAllPlayers");
            this.lbAllPlayers.Name = "lbAllPlayers";
            // 
            // flowPnlFavoritePlayers
            // 
            resources.ApplyResources(this.flowPnlFavoritePlayers, "flowPnlFavoritePlayers");
            this.flowPnlFavoritePlayers.AllowDrop = true;
            this.flowPnlFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPnlFavoritePlayers.Name = "flowPnlFavoritePlayers";
            this.flowPnlFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowPnlFavoritePlayers_DragDrop);
            this.flowPnlFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowPanels_DragEnter);
            // 
            // flowPnlAllPlayers
            // 
            resources.ApplyResources(this.flowPnlAllPlayers, "flowPnlAllPlayers");
            this.flowPnlAllPlayers.AllowDrop = true;
            this.flowPnlAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPnlAllPlayers.Name = "flowPnlAllPlayers";
            this.flowPnlAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowPnlAllPlayers_DragDrop);
            this.flowPnlAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowPanels_DragEnter);
            // 
            // tabRankedPlayers
            // 
            resources.ApplyResources(this.tabRankedPlayers, "tabRankedPlayers");
            this.tabRankedPlayers.Controls.Add(this.btnPrintCards);
            this.tabRankedPlayers.Controls.Add(this.btnPrintGoals);
            this.tabRankedPlayers.Controls.Add(this.lbTeamNameTab2);
            this.tabRankedPlayers.Controls.Add(this.label2);
            this.tabRankedPlayers.Controls.Add(this.label1);
            this.tabRankedPlayers.Controls.Add(this.flowPnlCards);
            this.tabRankedPlayers.Controls.Add(this.flowPnlGoals);
            this.tabRankedPlayers.Name = "tabRankedPlayers";
            this.tabRankedPlayers.UseVisualStyleBackColor = true;
            this.tabRankedPlayers.Enter += new System.EventHandler(this.tabRankedPlayers_Enter);
            // 
            // btnPrintCards
            // 
            resources.ApplyResources(this.btnPrintCards, "btnPrintCards");
            this.btnPrintCards.Name = "btnPrintCards";
            this.btnPrintCards.UseVisualStyleBackColor = true;
            this.btnPrintCards.Click += new System.EventHandler(this.btnPrintCards_Click);
            // 
            // btnPrintGoals
            // 
            resources.ApplyResources(this.btnPrintGoals, "btnPrintGoals");
            this.btnPrintGoals.Name = "btnPrintGoals";
            this.btnPrintGoals.UseVisualStyleBackColor = true;
            this.btnPrintGoals.Click += new System.EventHandler(this.btnPrintGoals_Click);
            // 
            // lbTeamNameTab2
            // 
            resources.ApplyResources(this.lbTeamNameTab2, "lbTeamNameTab2");
            this.lbTeamNameTab2.Name = "lbTeamNameTab2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // flowPnlCards
            // 
            resources.ApplyResources(this.flowPnlCards, "flowPnlCards");
            this.flowPnlCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPnlCards.Name = "flowPnlCards";
            // 
            // flowPnlGoals
            // 
            resources.ApplyResources(this.flowPnlGoals, "flowPnlGoals");
            this.flowPnlGoals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPnlGoals.Name = "flowPnlGoals";
            // 
            // tabPageRankedGames
            // 
            resources.ApplyResources(this.tabPageRankedGames, "tabPageRankedGames");
            this.tabPageRankedGames.Controls.Add(this.btnPrintGames);
            this.tabPageRankedGames.Controls.Add(this.lbTeamNameTab3);
            this.tabPageRankedGames.Controls.Add(this.flowLayoutPnlGames);
            this.tabPageRankedGames.Name = "tabPageRankedGames";
            this.tabPageRankedGames.UseVisualStyleBackColor = true;
            this.tabPageRankedGames.Enter += new System.EventHandler(this.tabPageRankedGames_Enter);
            // 
            // btnPrintGames
            // 
            resources.ApplyResources(this.btnPrintGames, "btnPrintGames");
            this.btnPrintGames.Name = "btnPrintGames";
            this.btnPrintGames.UseVisualStyleBackColor = true;
            this.btnPrintGames.Click += new System.EventHandler(this.btnPrintGames_Click);
            // 
            // lbTeamNameTab3
            // 
            resources.ApplyResources(this.lbTeamNameTab3, "lbTeamNameTab3");
            this.lbTeamNameTab3.Name = "lbTeamNameTab3";
            // 
            // flowLayoutPnlGames
            // 
            resources.ApplyResources(this.flowLayoutPnlGames, "flowLayoutPnlGames");
            this.flowLayoutPnlGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPnlGames.Name = "flowLayoutPnlGames";
            // 
            // printPreviewDialogGoals
            // 
            resources.ApplyResources(this.printPreviewDialogGoals, "printPreviewDialogGoals");
            this.printPreviewDialogGoals.Document = this.printDocumentGoals;
            this.printPreviewDialogGoals.Name = "printPreviewDialog";
            // 
            // printDocumentGoals
            // 
            this.printDocumentGoals.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialogCards
            // 
            resources.ApplyResources(this.printPreviewDialogCards, "printPreviewDialogCards");
            this.printPreviewDialogCards.Document = this.printDocumentCards;
            this.printPreviewDialogCards.Name = "printPreviewDialogCards";
            // 
            // printDocumentCards
            // 
            this.printDocumentCards.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentCards_PrintPage);
            // 
            // printPreviewDialogGames
            // 
            resources.ApplyResources(this.printPreviewDialogGames, "printPreviewDialogGames");
            this.printPreviewDialogGames.Document = this.printDocumentGames;
            this.printPreviewDialogGames.Name = "printPreviewDialogGames";
            // 
            // printDocumentGames
            // 
            this.printDocumentGames.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentGames_PrintPage);
            // 
            // cmsEditPlayer
            // 
            resources.ApplyResources(this.cmsEditPlayer, "cmsEditPlayer");
            this.cmsEditPlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEditPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePlayerPictureToolStripMenuItem,
            this.changePanelToolStripMenuItem});
            this.cmsEditPlayer.Name = "cmsEditPlayer";
            // 
            // changePlayerPictureToolStripMenuItem
            // 
            resources.ApplyResources(this.changePlayerPictureToolStripMenuItem, "changePlayerPictureToolStripMenuItem");
            this.changePlayerPictureToolStripMenuItem.Name = "changePlayerPictureToolStripMenuItem";
            this.changePlayerPictureToolStripMenuItem.Click += new System.EventHandler(this.changePlayerPictureToolStripMenuItem_Click);
            // 
            // changePanelToolStripMenuItem
            // 
            resources.ApplyResources(this.changePanelToolStripMenuItem, "changePanelToolStripMenuItem");
            this.changePanelToolStripMenuItem.Name = "changePanelToolStripMenuItem";
            this.changePanelToolStripMenuItem.Click += new System.EventHandler(this.changePanelToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            this.menuStrip.Name = "menuStrip";
            // 
            // menuItemFile
            // 
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSettings});
            this.menuItemFile.Name = "menuItemFile";
            // 
            // toolStripMenuItemSettings
            // 
            resources.ApplyResources(this.toolStripMenuItemSettings, "toolStripMenuItemSettings");
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.toolStripMenuItemSettings_Click);
            // 
            // menuItemHelp
            // 
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemContact});
            this.menuItemHelp.Name = "menuItemHelp";
            // 
            // toolStripMenuItemContact
            // 
            resources.ApplyResources(this.toolStripMenuItemContact, "toolStripMenuItemContact");
            this.toolStripMenuItemContact.Name = "toolStripMenuItemContact";
            this.toolStripMenuItemContact.Click += new System.EventHandler(this.toolStripMenuItemContact_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.tabMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.tabMainForm.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            this.tabPlayers.PerformLayout();
            this.tabRankedPlayers.ResumeLayout(false);
            this.tabRankedPlayers.PerformLayout();
            this.tabPageRankedGames.ResumeLayout(false);
            this.tabPageRankedGames.PerformLayout();
            this.cmsEditPlayer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainForm;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.Label lbTeamNameTab1;
        private System.Windows.Forms.Label lbFavoritePlayers;
        private System.Windows.Forms.Label lbAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel flowPnlFavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel flowPnlAllPlayers;
        private System.Windows.Forms.TabPage tabRankedPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPnlCards;
        private System.Windows.Forms.FlowLayoutPanel flowPnlGoals;
        private System.Windows.Forms.Label lbTeamNameTab2;
        private System.Windows.Forms.TabPage tabPageRankedGames;
        private System.Windows.Forms.Label lbTeamNameTab3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPnlGames;
        private System.Windows.Forms.Button btnPrintCards;
        private System.Windows.Forms.Button btnPrintGoals;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogGoals;
        private System.Drawing.Printing.PrintDocument printDocumentGoals;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogCards;
        private System.Drawing.Printing.PrintDocument printDocumentCards;
        private System.Windows.Forms.Button btnPrintGames;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogGames;
        private System.Drawing.Printing.PrintDocument printDocumentGames;
        private System.Windows.Forms.ContextMenuStrip cmsEditPlayer;
        private System.Windows.Forms.ToolStripMenuItem changePlayerPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePanelToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContact;
    }
}