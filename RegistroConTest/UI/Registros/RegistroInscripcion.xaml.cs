using Microsoft.EntityFrameworkCore;
using RegistroConTest.BLL;
using RegistroConTest.DAL;
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
            Monto1Textbox.Text = "0";
            BalanceTextbox.Text = string.Empty;
            FechaPicker.SelectedDate = DateTime.Now;
            ComentarioTextbox.Text = string.Empty;
        }

        private void LlenaCampo(Inscripciones inscripcion)
        {
            IdPersonaTextbox.Text = Convert.ToString(inscripcion.PersonaID);
            IdInscripcionTextbox.Text = Convert.ToString(inscripcion.InscripcionID);
            Monto1Textbox.Text = Convert.ToString(inscripcion.Monto);
            BalanceTextbox.Text = Convert.ToString(inscripcion.Balance);
            FechaPicker.SelectedDate = inscripcion.Fecha;

        }

        private bool validar()
        {
            bool paso = true;
            //  MyErrorProvider.Clear();

            if (IdInscripcionTextbox.Text == "0")
            {
                MessageBox.Show("Este Campo no puede estar vacio");
                // MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                IdInscripcionTextbox.Focus();
                paso = false;
            }

            if (IdPersonaTextbox.Text == "0")
            {
                MessageBox.Show("Este Campo no puede estar vacio");
                // MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                IdPersonaTextbox.Focus();
                paso = false;
            }

            if (BalanceTextbox.Text == "0")
            {
                MessageBox.Show("Este Campo no puede estar vacio");
                // MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                BalanceTextbox.Focus();
                paso = false;
            }

            if (Monto1Textbox.Text == "0")
            {
                MessageBox.Show("Este Campo no puede estar vacio");
                //  MyErrorProvider.SetError(DireccionTextBox, "El campo no puede esta vacio");
                Monto1Textbox.Focus();
                paso = false;
            }

            return paso;

        }

        private Inscripciones LlenaClase()
        {
            Contexto db = new Contexto();
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionID = Convert.ToInt32(IdInscripcionTextbox.Text);
            inscripcion.Fecha = Convert.ToDateTime(FechaPicker.SelectedDate);
            inscripcion.PersonaID = Convert.ToInt32(IdPersonaTextbox.Text);
            inscripcion.Comentarios = ComentarioTextbox.Text;
            inscripcion.Monto = Convert.ToInt32(Monto1Textbox.Text);
            inscripcion.Balance = Convert.ToInt32(BalanceTextbox.Text);

            Persona persona = PersonaBLL.Buscar(Convert.ToInt32(IdPersonaTextbox.Text)); //
            persona.Balance += inscripcion.Balance; //
            db.Entry(persona).State = EntityState.Modified;
            db.SaveChanges();

            return inscripcion;
        }

        private bool ExisteEnLaBaseDeDatos() // VERIFICA SI UNA PERSONA EXISTE EN LA BASE DE DATOS
        {
            Inscripciones inscripcion = InscripcionesBLL.Buscar(Convert.ToInt32(IdInscripcionTextbox.Text));
            return (inscripcion != null);
        }

        private void GuardarButton(object sender, RoutedEventArgs e)
        {
           Inscripciones inscripcion;

            bool paso = false;
            if (!validar())
                return;

            inscripcion = LlenaClase();



            if (IdInscripcionTextbox.Text == "0")
            {
                paso = InscripcionesBLL.Guardar(inscripcion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("NO SE PUEDE MOFICICAR PERSONAS QUE NO EXISTEN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }


            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con EXITO!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void ButtonBuscar(object sender, RoutedEventArgs e)
        {
            int ID;
            Inscripciones inscripcion = new Inscripciones();

            int.TryParse(IdInscripcionTextbox.Text, out ID);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(ID);

            if (inscripcion != null)
            {
                MessageBox.Show("PERSONA ENCONTRADA");
                LlenaCampo(inscripcion);
            }
        }

        private void ButtonEliminar(object sender, RoutedEventArgs e)
        {
            int ID;
            Inscripciones inscripcion = new Inscripciones();

            int.TryParse(IdInscripcionTextbox.Text, out ID);

            Limpiar();

            if (PersonaBLL.Eliminar(ID))
            {
                Contexto db = new Contexto();

                Persona persona =PersonaBLL.Buscar(Convert.ToInt32(IdPersonaTextbox.Text));   //

                persona.Balance -= (Convert.ToSingle(BalanceTextbox.Text)); //
                db.Entry(persona).State = EntityState.Modified;  //
                db.SaveChanges();

                MessageBox.Show("ELiminado", "EXITOO!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

                
        }
    }
}

  
