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
    /// Lógica interna para UsuarioWindow.xaml
    /// </summary>
    public partial class UsuarioWindow : Window
    {
        public UsuarioWindow()
        {
            InitializeComponent();
            userPesquisaContatoComboBox.Items.Add("Escolher");
            userPesquisaContatoComboBox.Items.Add("Nome");
            userPesquisaContatoComboBox.Items.Add("E-mail");
            userPesquisaContatoComboBox.Items.Add("Telefone");
            userPesquisaContatoComboBox.SelectedItem = "Escolher";
        }


        private void SairClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addContatoClick(object sender, RoutedEventArgs e)
        {
            // adicionar
        }

        private void userPesquisaContatoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comboBox userPesquisaContato
        }
    }
}
