using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Lógica interna para AdicionarContatoWindow.xaml
    /// </summary>
    public partial class AdicionarContatoWindow : Window
    {
        public AdicionarContatoWindow()
        {
            InitializeComponent();
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            // adicionar contato
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
