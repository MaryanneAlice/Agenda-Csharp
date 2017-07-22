using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Lógica interna para AdmWindow.xaml
    /// </summary>
    public partial class AdmWindow : Window
    {
        public AdmWindow()
        {
            InitializeComponent();
            updateGrid();
        }
        
        public void updateGrid()
        {
           gridVisualizacaoAdm.ItemsSource = null;
           gridVisualizacaoAdm.ItemsSource = negocioUsuario.Selecionar();
        }

        Business.Usuario negocioUsuario = new Business.Usuario();
        AdicionarUsuarioWindow adicionarUser = new AdicionarUsuarioWindow();
        AcessosWindow acessosLog = new AcessosWindow();

        private void AcessosClick(object sender, RoutedEventArgs e)
        {
            acessosLog.ShowDialog();
        }

        private void AdicionarClick(object sender, RoutedEventArgs e)
        {
                adicionarUser.ShowDialog();           
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
           updateGrid();
        }
    }
}
