using System.Windows;

namespace WitteGijUtKwis
{

    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_Register_OnClick(object sender, RoutedEventArgs e)
        {
            var register = new Register();
            register.ShowDialog();
        }

        private void Btn_Login_OnClick(object sender, RoutedEventArgs e)
        {
            var loginmanager = new LoginManager();

            if (!loginmanager.CheckLogin(Txt_Username.Text, Txt_Password.Password))
            {
                MessageBox.Show("De spelersnaam en wachtwoord komen niet overeen", "Error");
                return;
            }

            DialogResult = true;
        }
    }
}
