using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WitteGijUtKwis
{
    public partial class Register
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Btn_Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            var loginmanager = new LoginManager();

            if (Txt_Wachtwoord.Password != Txt_WachtwoordHerhaal.Password)
            {
                MessageBox.Show("De wachtwoorden die je in hebt gevult zijn niet hetzelfde", "Error");
                Txt_WachtwoordHerhaal.Password = "";
                return;
            }

            if (!loginmanager.CheckRegister(Txt_Spelersnaam.Text, Txt_Wachtwoord.Password, Txt_Plaatsnaam.Text, Convert.ToInt32(Txt_Leeftijd.Text)))
            {
                MessageBox.Show("De spelersnaam bestaat al", "Error");
                return;
            }

            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
