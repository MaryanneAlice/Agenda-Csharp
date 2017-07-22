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
    /// Lógica interna para AdicionarWindow.xaml
    /// </summary>
    public partial class AdicionarUsuarioWindow : Window
    {
        
        Business.Usuario negocioUsuario = new Business.Usuario();
        Model.Usuario modeloUsuario = new Model.Usuario();

        public AdicionarUsuarioWindow()
        {

            InitializeComponent();
            // opcoes comboBox Add
            admAddUserComboBox.Items.Add("Escolher");
            admAddUserComboBox.Items.Add(true);
            admAddUserComboBox.Items.Add(false);
            admAddUserComboBox.SelectedItem = "Escolher";

            try
            {
                modeloUsuario.Id = 1;
                modeloUsuario.Login = "admin";
                modeloUsuario.Senha = Persistence.Criptografar.MD5Hash("admin");
                modeloUsuario.Admin = true;
                negocioUsuario.Inserir(modeloUsuario);
            }
            catch (ArgumentNullException) { }
            catch (InvalidOperationException) { }

        }


        private void AdmAddUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // combox admAddComboBox
        }

        private void Canccelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
           var IDultimo = negocioUsuario.Selecionar().OrderBy(user => user.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;

    
            try
            {
                modeloUsuario.Id = IDultimo + 1;
                modeloUsuario.Login = textCadastroLogin.Text;
                modeloUsuario.Senha = Persistence.Criptografar.MD5Hash(textCadastroLoginSenha.Text);
                var opcao = admAddUserComboBox.Text;
                modeloUsuario.Admin = Boolean.Parse(opcao);
                negocioUsuario.Inserir(modeloUsuario);

                MessageBox.Show("Salvo com sucesso!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dados nao informados!");
            } 
            catch (InvalidOperationException)
            {
                MessageBox.Show("Usuario ja cadastrado!");
            }
            catch (FormatException)
            {
                MessageBox.Show("o usuario necessita ter status (verdadeiro ou falso) de administrador!!! ");
            }


        }
    }

}
