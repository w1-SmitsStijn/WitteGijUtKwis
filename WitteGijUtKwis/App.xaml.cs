using System.Windows;

namespace WitteGijUtKwis
{
    public partial class App
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Login login = new Login();

            if (login.ShowDialog() == true)
            {
                var frm = new MainWindow();
                frm.ShowDialog();
            }

            else
            {
                Current.Shutdown();
            }
        }
    }
}
