using RegistroConTest.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroConTest.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroInscripcion.xaml
    /// </summary>
    public partial class RegistroInscripcion : Window
    {
        public RegistroInscripcion()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdInscripcionTextbox.Text = "0";
            IdPersonaTextbox.Text = "0";
            MontoTextbox.Text = "0";
            BalanceTextbox.Text = string.Empty;
            FechaPicker.SelectedDate = DateTime.Now;
            ComentarioTextbox.Text = string.Empty;
        }

        private void LlenaCampo(Inscripciones inscripcion)
        {
            IdPersonaTextbox.Text = Convert.ToString(inscripcion.PersonaID);
            IdInscripcionTextbox.Text = Convert.ToString(inscripcion.InscripcionID);
            MontoTextbox.Text = Convert.ToString(inscripcion.Monto);
            BalanceTextbox.Text = Convert.ToString(inscripcion.Balance);
            FechaPicker.SelectedDate = inscripcion.Fecha;

        }

        private void NuevoButton(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
