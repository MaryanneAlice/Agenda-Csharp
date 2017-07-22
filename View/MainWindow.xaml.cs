using System.Windows;
using System;
using System.Linq;

namespace View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Business.Usuario negocioUsuario = new Business.Usuario();
        Model.Usuario modeloUsuario = new Model.Usuario();
        Model.Acesso modeloAcesso = new Model.Acesso();
        Business.Acessos negocioAcesso = new Business.Acessos();



        AdmWindow admJanela = new AdmWindow();
        UsuarioWindow userJanela = new UsuarioWindow();

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {

             
                string login = txtLogin.Text;
                string senha = Persistence.Criptografar.MD5Hash(txtSenha.Password.ToString());

              var adminStatus = negocioUsuario.Selecionar().Where(person => person.Login == login && person.Senha == senha).Single().Admin;
                var idUser = negocioUsuario.Selecionar().Where(person => person.Login == login && person.Senha == senha).Single().Id;

                modeloUsuario.Login = login;
                modeloUsuario.Senha = senha;

                if (adminStatus == true)
                {
                    admJanela.ShowDialog();
                }
                else if (adminStatus == false)
                {
                    userJanela.ShowDialog();

                    modeloAcesso.Id = 1;
                    modeloAcesso.IdUsuario = modeloUsuario.Id;
                    modeloAcesso.Data = DateTime.Now;
                    negocioAcesso.Inserir(modeloAcesso);

                }
            
        }
    }
}
