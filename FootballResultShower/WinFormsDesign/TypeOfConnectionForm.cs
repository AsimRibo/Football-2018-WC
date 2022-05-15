using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.APIHandler;
using Utilities.Enums;

namespace WinFormsDesign
{
    public partial class TypeOfConnectionForm : Form
    {
        private const string EN = "en", HR = "hr";

        public TypeOfConnectionForm()
        {
            InitializeComponent();
        }

        private void TypeOfConnectionForm_Load(object sender, EventArgs e)
        {
            PrepareComboBox(cmbConnection, ConnectionType.Offline.ToString(), ConnectionType.Online.ToString());
            PrepareComboBox(cmbLanguage, HR, EN);
            PrepareComboBox(cmbSex, Sex.Male.ToString(), Sex.Female.ToString());
        }

        private void PrepareComboBox(ComboBox comboBox, params string[] comboBoxValues)
        {
            comboBoxValues.ToList().ForEach(item => comboBox.Items.Add(item));
            comboBox.SelectedIndex = 0;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(MessageRes.settingsMsg, MessageRes.settingsTitle, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                UserSettings.Selectedlanguage = (string)cmbLanguage.SelectedItem;
                UserSettings.Sex = (Sex)Enum.Parse(typeof(Sex), (string)cmbSex.SelectedItem);
                UserSettings.ConnectionType = (ConnectionType)Enum.Parse(typeof(ConnectionType), (string)cmbConnection.SelectedItem);

                switch (UserSettings.ConnectionType)
                {
                    case ConnectionType.Online:
                        SetOnlineSettings();
                        break;
                    case ConnectionType.Offline:
                        SetOfflineSettings();
                        break;
                }
                

                Dispose();
                new TeamForm().ShowDialog();
            }
        }

        private void SetOfflineSettings()
        {
            switch (UserSettings.Sex)
            {
                case Sex.Male:
                    UserSettings.DefaultFolder = APIConstants.MenFolder;
                    break;
                case Sex.Female:
                    UserSettings.DefaultFolder = APIConstants.WomenFolder;
                    break;
            }
        }

        private void SetOnlineSettings()
        {
            switch (UserSettings.Sex)
            {
                case Sex.Male:
                    UserSettings.BaseUrl = APIConstants.MaleBaseUrl;
                    break;
                case Sex.Female:
                    UserSettings.BaseUrl = APIConstants.FemaleBaseUrl;
                    break;
            }
        }
    }
}
