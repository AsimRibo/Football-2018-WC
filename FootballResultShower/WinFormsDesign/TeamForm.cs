using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using Utilities.APIHandler;
using Utilities.DAL;
using Utilities.Enums;

namespace WinFormsDesign
{
    public partial class TeamForm : Form
    {
        private readonly IDataHandling repository;

        public TeamForm()
        {
            InitializeComponent();
            repository = RepositoryFactory.GetRepository(UserSettings.ConnectionType);
        }

        private void TeamForm_Load(object sender, EventArgs e)
        {
            PrepareComboBox();
        }

        private async void PrepareComboBox()
        {
            try
            {
                progressBar.Value = 40;
                IList<FootballTeam> teams = await repository.GetTeamsAsync();
                teams.ToList().ForEach(team => cmbTeam.Items.Add(team));
                progressBar.Value = 100;
                cmbTeam.SelectedIndex = 0;
            }
            catch (Exception)
            {
                if (MessageBox.Show(MessageRes.errorMsg, MessageRes.errorTitle, MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Exit();
            }

        }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UserSettings.SelectedFootballTeam = ((FootballTeam)cmbTeam.SelectedItem).Country;
            UserSettings.FifaCode = ((FootballTeam)cmbTeam.SelectedItem).FifaCode;
            Dispose();
        }

    }
}
