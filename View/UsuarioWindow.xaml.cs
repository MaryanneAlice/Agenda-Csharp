using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
            optionsComboBOX();
            updateGrid();
            InitializeWindow();

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

        

        private void optionsComboBOX()
        {
            userPesquisaContatoComboBox.Items.Add("Escolher");
            userPesquisaContatoComboBox.Items.Add("Nome");
            userPesquisaContatoComboBox.Items.Add("E-mail");
            userPesquisaContatoComboBox.Items.Add("Telefone");
            userPesquisaContatoComboBox.SelectedItem = "Escolher";
        }

        Business.Contato negocioContato = new Business.Contato();
        Model.Contato modeloContato = new Model.Contato();
        Model.Usuario modeloUsuario = new Model.Usuario();

        Business.Acessos negocioAcessos = new Business.Acessos();
        Business.Usuario negocioUsuario = new Business.Usuario();

        AdicionarContatoWindow addContatoJanela = new AdicionarContatoWindow();

        public void InitializeWindow()
        {
            userNomeEditar.Visibility = System.Windows.Visibility.Collapsed;
            textuserNomeEditar.Visibility = System.Windows.Visibility.Collapsed;
            userTelefoneEditar.Visibility = System.Windows.Visibility.Collapsed;
            textuserTelefoneEditar.Visibility = System.Windows.Visibility.Collapsed;
            userEmailEditar.Visibility = System.Windows.Visibility.Collapsed;
            textuserEmailEditar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Atualizar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Fechar.Visibility = System.Windows.Visibility.Collapsed;
            gridVisualizarContatos.Margin = new Thickness(20, 20, 20, 20);
        }

        public void updateGrid()
        {
            int idUser = negocioAcessos.Selecionar().OrderBy(user => user.Data).OrderBy(x => x.Data).Take(1).Single().IdUsuario;
            string nomeUser = negocioUsuario.Selecionar().Where(person => person.Id == idUser).Single().Login;

            gridVisualizarContatos.ItemsSource = null;
            gridVisualizarContatos.ItemsSource = negocioContato.Selecionar(nomeUser).OrderBy(person => person.Nome);

        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void addContatoClick(object sender, RoutedEventArgs e)
        {
            addContatoJanela.ShowDialog();
        }

        private void userPesquisaContatoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comboBox userPesquisaContato
        }


        private void ApagarUsuarioClick(object sender, RoutedEventArgs e)
        {
            int idUser = negocioAcessos.Selecionar().OrderBy(user => user.Data).OrderBy(x => x.Data).Take(1).Single().IdUsuario;
            string nomeUser = negocioUsuario.Selecionar().Where(person => person.Id == idUser).Single().Login;

            modeloContato = gridVisualizarContatos.SelectedItem as Model.Contato;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente DELETAR esse usuário?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                negocioContato.Deletar(modeloContato, nomeUser);
            }

            updateGrid();
        }

        private void EditarUsuarioClick(object sender, RoutedEventArgs e)
        {
            userNomeEditar.Visibility = System.Windows.Visibility.Visible;
            textuserNomeEditar.Visibility = System.Windows.Visibility.Visible;
            userTelefoneEditar.Visibility = System.Windows.Visibility.Visible;
            textuserTelefoneEditar.Visibility = System.Windows.Visibility.Visible;
            userEmailEditar.Visibility = System.Windows.Visibility.Visible;
            textuserEmailEditar.Visibility = System.Windows.Visibility.Visible;
            btn_Atualizar.Visibility = System.Windows.Visibility.Visible;
            btn_Fechar.Visibility = System.Windows.Visibility.Visible;
            gridVisualizarContatos.Margin = new Thickness(-380, 120, 0, 0);
        }

        private void AtualizarContato_Click(object sender, RoutedEventArgs e)
        {
            int idUser = negocioAcessos.Selecionar().OrderBy(user => user.Data).OrderBy(x => x.Data).Take(1).Single().IdUsuario;
            string nomeUser = negocioUsuario.Selecionar().Where(person => person.Id == idUser).Single().Login;

            try
            {
                modeloContato = gridVisualizarContatos.SelectedItem as Model.Contato;
                int idContato = modeloContato.Id;
                modeloContato.Nome = textuserNomeEditar.Text;
                modeloContato.Telefone = textuserTelefoneEditar.Text;
                modeloContato.Email = textuserEmailEditar.Text;

                negocioContato.Atualizar(modeloContato, nomeUser);

                MessageBox.Show("Contato atualizado com sucesso!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dados nao informados!");
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

        private void gridVisualizarContatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridVisualizarContatos.SelectedItem != null)
            {
                Model.Contato c = (Model.Contato)gridVisualizarContatos.SelectedItem;
                textuserNomeEditar.Text = c.Nome;
            }
        }

        private void Pesquisar_Click(object sender, RoutedEventArgs e)
        {
            string nomeUser = modeloUsuario.Login;
            string opcao = userPesquisaContatoComboBox.Text;
            string dado = textUserPesquisarContatos.Text;

            if (opcao == "Nome")
            {
                var users = negocioContato.Selecionar(nomeUser).Where(person => person.Nome == dado).ToList();
                updateGrid();
            }
            else if (opcao == "E-mail")
            {
                var users = negocioContato.Selecionar(nomeUser).Where(person => person.Email == dado).ToList();
                updateGrid();
            }
            else if (opcao == "Telefone")
            {
                var users = negocioContato.Selecionar(nomeUser).Where(person => person.Telefone == dado).ToList();
                updateGrid();
            }

        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            updateGrid();
        }


        private void gridVisualizarContatos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
            {
                e.Cancel = true;
            }
        }
    }
}
