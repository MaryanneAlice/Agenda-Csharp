using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Controls;
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
            addComboBOX();
            InitializeWindow();

            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        public void InitializeWindow()
        {
            admLoginLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            admSenhaLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            admAddLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            textLoginEditar.Visibility = System.Windows.Visibility.Collapsed; 
            textSenhaEditar.Visibility = System.Windows.Visibility.Collapsed;
            admUserComboBoxEditar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Atualizar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Fechar.Visibility = System.Windows.Visibility.Collapsed;
            gridVisualizacaoAdm.Margin = new Thickness(20, 20, 20, 20);
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
           gridVisualizacaoAdm.ItemsSource = negocioUsuario.Selecionar().OrderBy(person => person.Id);
        }

        Business.Usuario negocioUsuario = new Business.Usuario();
        Model.Usuario modeloUsuario = new Model.Usuario();
        AdicionarUsuarioWindow adicionarUser = new AdicionarUsuarioWindow();
        AcessosWindow acessosLog = new AcessosWindow();


        public void addComboBOX()
        {
            admUserComboBoxEditar.Items.Add("Escolher");
            admUserComboBoxEditar.Items.Add(true);
            admUserComboBoxEditar.Items.Add(false);
            admUserComboBoxEditar.SelectedItem = "Escolher";
        }

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
            admLoginLabelEditar.Visibility = System.Windows.Visibility.Visible;
            admSenhaLabelEditar.Visibility = System.Windows.Visibility.Visible;
            admAddLabelEditar.Visibility = System.Windows.Visibility.Visible;
            textLoginEditar.Visibility = System.Windows.Visibility.Visible;
            textSenhaEditar.Visibility = System.Windows.Visibility.Visible;
            admUserComboBoxEditar.Visibility = System.Windows.Visibility.Visible;
            btn_Atualizar.Visibility = System.Windows.Visibility.Visible;
            btn_Fechar.Visibility = System.Windows.Visibility.Visible;
            gridVisualizacaoAdm.Margin = new Thickness(-360, 120, 0, 0);
        }

        private void AtualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                modeloUsuario = gridVisualizacaoAdm.SelectedItem as Model.Usuario;
                int idUser = modeloUsuario.Id;
                modeloUsuario.Login = textLoginEditar.Text;
                modeloUsuario.Senha = textSenhaEditar.Text;
                var opcao = admUserComboBoxEditar.Text;
                modeloUsuario.Admin = Boolean.Parse(opcao);

                negocioUsuario.Atualizar(modeloUsuario);

                MessageBox.Show("Usuario atualizado com sucesso!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dados nao informados!");
            }
            catch (FormatException)
            {
                MessageBox.Show("o usuario necessita ter status (verdadeiro ou falso) de administrador!!! ");
            }
            finally
            {
                updateGrid();
                InitializeWindow();
            }

        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            InitializeWindow();
        }

        private void gridVisualizacaoAdm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridVisualizacaoAdm.SelectedItem != null)
            {
                Model.Usuario u = (Model.Usuario)gridVisualizacaoAdm.SelectedItem;
                textLoginEditar.Text = u.Login;
            }
        }
    }
}
