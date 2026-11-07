using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MiPresentacion
{
    public partial class MainWindow : Window
    {
        private bool saludoAlternativo = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
        {
            string nombre = TxtNombre.Text?.Trim() ?? string.Empty;
            string apellido = TxtApellido.Text?.Trim() ?? string.Empty;
            string edadTexto = TxtEdad.Text?.Trim() ?? string.Empty;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                TxtResultado.Text = "⚠️ Advertencia: El nombre y el apellido no pueden estar vacíos.";
                return;
            }

            // Validar que la edad sea un número entero positivo
            if (!int.TryParse(edadTexto, out int edad) || edad <= 0)
            {
                TxtResultado.Text = "⚠️ Advertencia: La edad debe ser un número entero válido mayor a cero.";
                return;
            }

            // Mostrar resultado según el saludo seleccionado
            if (saludoAlternativo)
            {
                TxtResultado.Text = $"¡Hola de nuevo! Soy {nombre} {apellido}, tengo {edad} años y sigo practicando con Avalonia UI.";
            }
            else
            {
                TxtResultado.Text = $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edad} años y estoy aprendiendo\na desarrollar interfaces gráficas con C#.";
            }
        }

        private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
        {
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtEdad.Text = string.Empty;
            TxtResultado.Text = "Aquí aparecerá tu presentación o mensajes de validación...";
            
            // Colocar el cursor nuevamente en el nombre
            TxtNombre.Focus();
        }

        private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
        {
            saludoAlternativo = !saludoAlternativo;
            string tipo = saludoAlternativo ? "Alternativo" : "Clásico";
            TxtResultado.Text = $"🔄 Modo de saludo cambiado a: {tipo}. Presiona 'Presentarme'.";
        }
    }
}