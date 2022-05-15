using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utilities.APIHandler;
using Utilities.Enums;

namespace WPFDesign
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const string EN = "en", HR = "hr";
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.saveMsg, Properties.Resources.saveTitle, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                SetSex();
                SetConnectionType();
                SetLanguage();
                SetScreenSize();
                switch (UserSettings.ConnectionType)
                {
                    case ConnectionType.Online:
                        SetOnlineSettings();
                        break;
                    case ConnectionType.Offline:
                        SetOfflineSettings();
                        break;
                }

                Close();
            }
        }

        private void SetScreenSize()
        {
            UserSettings.ScreenSize = (ScreenSize)cbScreenSize.SelectedItem;
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


        private void SetLanguage()
        {
            if ((bool)rbLanguageFirst.IsChecked)
            {
                UserSettings.Selectedlanguage = EN;
                return;
            }
            UserSettings.Selectedlanguage = HR;
        }

        private void SetConnectionType()
        {
            if ((bool)rbConnectionFirst.IsChecked)
            {
                UserSettings.ConnectionType = ConnectionType.Online;
                return;
            }
            UserSettings.ConnectionType = ConnectionType.Offline;
        }

        private void SetSex()
        {
            if ((bool)rbTypeFirst.IsChecked)
            {
                UserSettings.Sex = Sex.Male;
                return;
            }
            UserSettings.Sex = Sex.Female;
        }

        private void Init()
        {
            PrepareRadioButtons(rbLanguageFirst, rbLanguageSecond, EN, HR);
            PrepareRadioButtons(rbTypeFirst, rbTypeSecond, Sex.Male.ToString(), Sex.Female.ToString());
            PrepareRadioButtons(rbConnectionFirst, rbConnectionSecond, ConnectionType.Online.ToString(), ConnectionType.Offline.ToString());
            cbScreenSize.ItemsSource = Enum.GetValues(typeof(ScreenSize));
            cbScreenSize.SelectedIndex = 0;
        }

        private void PrepareRadioButtons(RadioButton firstRadioBtn, RadioButton secondRadioBtn, string firstValue, string secondValue)
        {
            firstRadioBtn.Content = firstValue;
            secondRadioBtn.Content = secondValue;
            firstRadioBtn.IsChecked = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}
