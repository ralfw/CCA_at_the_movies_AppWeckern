﻿using System;
using System.Windows;
using appweckern.contracts;

namespace appweckern.ui
{
    public partial class MainWindow : Window, IUI
    {
        public MainWindow() {
            InitializeComponent();
            btnStart.Click += (o, e) => WeckzeitGeändert();
            btnStop.Click += (o, e) => Stopp_gedrückt();
        }

        private void WeckzeitGeändert() {
            DateTime weckzeit;
            TimeSpan ruhezeit;

            if (txtWeckzeit.Text.Trim() == "") {
                weckzeit = new DateTime();
            }
            else if (!DateTime.TryParse(txtWeckzeit.Text, out weckzeit)) {
                MessageBox.Show("Die Weckzeit ist ungültig. Bitte geben Sie eine Uhrzeit ein im Format HH:MM:SS");
                return;
            }

            if (txtRuhezeit.Text.Trim() == "") {
                ruhezeit = new TimeSpan();
            }
            else if (!TimeSpan.TryParse(txtRuhezeit.Text, out ruhezeit)) {
                MessageBox.Show("Die Ruhezeit ist ungültig. Bitte geben Sie eine Dauer ein im Format HH:MM:SS");
                return;
            }

            if (weckzeit == new DateTime() && ruhezeit == new TimeSpan()) {
                MessageBox.Show("Sie müssen eine Weckzeit oder eine Ruhezeit eingeben.");
                return;
            }

            lblRestzeit.Visibility = Visibility.Visible;
            Weckzeit_geändert(new Tuple<DateTime, TimeSpan>(weckzeit, ruhezeit));
        }

        public void Öffnen() {
            
        }

        public void Uhrzeit(DateTime uhrzeit) {
            lblUhrzeit.Text = uhrzeit.ToLongTimeString();
        }

        public void Restzeit(TimeSpan restzeit) {
            lblRestzeit.Text = restzeit.ToString();
        }

        public void Abgelaufen()
        {
            lblRestzeit.Visibility = Visibility.Hidden;
        }

        public void Gestoppt() {
            lblRestzeit.Visibility = Visibility.Hidden;
        }

        public event Action<Tuple<DateTime, TimeSpan>> Weckzeit_geändert;

        public event Action Stopp_gedrückt;
    }
}