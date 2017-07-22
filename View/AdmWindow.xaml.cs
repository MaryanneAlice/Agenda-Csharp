using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace View
{
    /// <summary>
    /// Lógica interna para AdmWindow.xaml
    /// </summary>
    public partial class AdmWindow : Window
    {
        public AdmWindow()
        {
            this.Loaded += MyWindow_Loaded;
            InitializeComponent();
        }

        Business.Usuario negocioUsuario = new Business.Usuario();

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridVisualizacaoAdm.ItemsSource = null;
            gridVisualizacaoAdm.ItemsSource = negocioUsuario.Selecionar();
        }

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
            Close();
        }
    }
}
