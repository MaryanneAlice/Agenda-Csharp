using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Interop;
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
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        public void updateGrid()
        {
           gridVisualizacaoAdm.ItemsSource = null;
           gridVisualizacaoAdm.ItemsSource = negocioUsuario.Selecionar();
        }

        Business.Usuario negocioUsuario = new Business.Usuario();
        Model.Usuario modeloUsuario = new Model.Usuario();
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

        private void ApagarUsuarioClick(object sender, RoutedEventArgs e)
        {
            modeloUsuario = gridVisualizacaoAdm.SelectedItem as Model.Usuario;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente DELETAR esse usuário?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                negocioUsuario.Deletar(modeloUsuario);
            }

            updateGrid();
        }

        private void EditarUsuarioClick(object sender, RoutedEventArgs e)
        {
            //editar user
        }
    }
}
