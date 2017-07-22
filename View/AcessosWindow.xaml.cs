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
    /// Lógica interna para AcessosWindow.xaml
    /// </summary>
    public partial class AcessosWindow : Window
    {
        public AcessosWindow()
        {
            InitializeComponent();
            // opcoes comboBox Acessos
            admAcessosComboBox.Items.Add("Escolher");
            admAcessosComboBox.Items.Add("Id");
            admAcessosComboBox.Items.Add("Nome");
            admAcessosComboBox.SelectedItem = "Escolher";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void admAcessosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //comboBox admAcessosComboBo
        }
    }
}
