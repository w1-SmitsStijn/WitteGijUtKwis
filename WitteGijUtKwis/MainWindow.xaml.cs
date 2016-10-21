using System.IO.Ports;
using System.Windows;

namespace WitteGijUtKwis
{
    public partial class MainWindow
    {
        private SerialPort arduino;

        public MainWindow()
        {
            InitializeComponent();

            arduino = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM4",
                DataBits = 8,
                StopBits = StopBits.One

            };

            arduino.DataReceived += OnDataReceived;

            //arduino.Open();

        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string antwoord = arduino.ReadLine();

            arduino.WriteLine("Goed");
        }

        private void Btn_Start_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            var quiz = new Quiz();
            quiz.ShowDialog();
        }
    }
}
