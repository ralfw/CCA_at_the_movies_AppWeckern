using System;
using System.Windows;
using appweckern.contracts;

namespace appweckern.ui
{
    public partial class MainWindow : Window, IUI
    {
        public MainWindow() {
            InitializeComponent();
        }

        public void Öffnen() {
            
        }

        public void Uhrzeit(DateTime uhrzeit) {
            lblUhrzeit.Text = uhrzeit.ToLongTimeString();
        }

        public void Restzeit(TimeSpan restzeit) {
            throw new NotImplementedException();
        }

        public void Abgelaufen() {
            throw new NotImplementedException();
        }

        public void Gestoppt() {
            throw new NotImplementedException();
        }

        public event Action<Tuple<DateTime, TimeSpan>> Weckzeit_geändert;
        public event Action Stopp_gedrückt;
    }
}