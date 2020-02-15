using RegistroConTest.BLL;
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
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void BalanceTextbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Limpiar()
        {
            IdTextbox1.Text = "0";
            NombreTextbox1.Text = string.Empty;
            CedulaTextbox1.Text = string.Empty;
            TelefonoTextbox1.Text = string.Empty;
            DireccionTextbox1.Text = string.Empty;
            BalanceTextbox1.Text = string.Empty;
            FechaPicker1.SelectedDate = DateTime.Now;
        }

        private void LlenaCampo(Persona persona)
        {
            IdTextbox1.Text = Convert.ToString(persona.PersonaId);
            NombreTextbox1.Text =persona.Nombres;
            CedulaTextbox1.Text =persona.Cedula;
            TelefonoTextbox1.Text= persona.Telefono;
            DireccionTextbox1.Text = persona.Direccion;
            BalanceTextbox1.Text = Convert.ToString(persona.Balance);
            FechaPicker1.SelectedDate = persona.FechaNacimiento;

        }

        private bool Corregir()     // CREE ESTE METODO PARA QUE CAPTURE ERRORES CUANDO SE DEJA ALGUN CAMPO VACIO, 
                                    // YA QUE EL METODO DEL PDF NO ME APARECE
        {
            bool estado = false;

            if (string.IsNullOrWhiteSpace(IdTextbox1.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(NombreTextbox1.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(TelefonoTextbox1.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextbox1.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            return estado;
        }


        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaId = Convert.ToInt32(IdTextbox1.Text);
            persona.Nombres = NombreTextbox1.Text;
            persona.Telefono = TelefonoTextbox1.Text;
            persona.Cedula = CedulaTextbox1.Text;
            persona.Balance = float.Parse(BalanceTextbox1.Text);
            persona.Direccion = DireccionTextbox1.Text;
            persona.FechaNacimiento = Convert.ToDateTime(FechaPicker1.SelectedDate);

            return persona;
        }

        private bool ExisteEnLaBaseDeDatos() // VERIFICA SI UNA PERSONA EXISTE EN LA BASE DE DATOS
        {
            Persona persona = PersonaBLL.Buscar(Convert.ToInt32(IdTextbox1.Text));
            return (persona != null);
        }

        private bool validar()
        {
            bool paso = true;
            //  MyErrorProvider.Clear();

            if (NombreTextbox1.Text == String.Empty)
            {
                Corregir();
                // MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                NombreTextbox1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextbox1.Text))
            {
                Corregir();
                //  MyErrorProvider.SetError(DireccionTextBox, "El campo no puede esta vacio");
                DireccionTextbox1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextbox1.Text.Replace("-", "")))
            {
                Corregir();
                //   MyErrorProvider.SetError.SetError(CedulaTextBox, "El campo cedula no puede estar vacio");
                CedulaTextbox1.Focus();
                paso = false;
            }

            return paso;

        }

        private void ButtonNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void ButtonGuardar(object sender, RoutedEventArgs e)
        {
            Persona persona;

            bool paso = false;
            if (!validar())
                return;

            persona = LlenaClase();

            

            if (IdTextbox1.Text == "0")
            {
                paso = PersonaBLL.Guardar(persona);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("NO SE PUEDE MOFICICAR PERSONAS QUE NO EXISTEN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonaBLL.Modificar(persona);
            }


            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con EXITO!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void ButtonEliminar(object sender, RoutedEventArgs e)
        {
            int ID;
            Persona persona = new Persona();

            int.TryParse(IdTextbox1.Text, out ID);

            Limpiar();

            if (PersonaBLL.Eliminar(ID))
                MessageBox.Show("ELiminado", "EXITOO!!!", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        private void ButtonBuscar(object sender, RoutedEventArgs e)
        {
            int ID;
            Persona persona = new Persona();

            int.TryParse(IdTextbox1.Text, out ID);

            Limpiar();

            persona = PersonaBLL.Buscar(ID);

            if (persona != null)
            {
                MessageBox.Show("PERSONA ENCONTRADA");
                LlenaCampo(persona);
            }
        }
    }
}
