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
    /// Lógica interna para AdicionarContatoWindow.xaml
    /// </summary>
    public partial class AdicionarContatoWindow : Window
    {
        public AdicionarContatoWindow()
        {
            InitializeComponent();
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

        Model.Usuario modeloUsuario = new Model.Usuario();
        Model.Contato modeloContato = new Model.Contato();
        Business.Contato negocioContato = new Business.Contato();
        Business.Acessos negocioAcessos = new Business.Acessos();
        Business.Usuario negocioUsuario = new Business.Usuario();

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {            
            var IDultimo = 0;
            try
            {
                int idUser = negocioAcessos.Selecionar().OrderBy(user => user.Data).OrderBy(x => x.Data).Take(1).Single().IdUsuario;
                string nomeUser = negocioUsuario.Selecionar().Where(person => person.Id == idUser).Single().Login;

                IDultimo = negocioContato.Selecionar(nomeUser).OrderBy(a => a.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;
            }
            catch (InvalidOperationException)
            {
                IDultimo = 0;
            }

            try
            {
                modeloContato.Id = IDultimo + 1;
                modeloContato.Nome = textNomeEditar.Text;
                modeloContato.Telefone = textTelefoneEditar.Text;
                modeloContato.Email = textEmailEditar.Text;

                // ultimo ser registrado no acesso

                int idUser = negocioAcessos.Selecionar().OrderBy(user => user.Data).OrderBy(x => x.Data).Take(1).Single().IdUsuario;
                string nomeUser = negocioUsuario.Selecionar().Where(person => person.Id == idUser).Single().Login;

                MessageBox.Show(nomeUser);
                negocioContato.Inserir(modeloContato, nomeUser);
                MessageBox.Show("Contato salvo com sucesso!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dados nao informados!");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
