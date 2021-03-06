﻿using System.Windows;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Interop;

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
        Business.Contato negocioContato = new Business.Contato();
        
        AdmWindow admJanela = new AdmWindow();
        UsuarioWindow userJanela = new UsuarioWindow();

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {

            int idAcesso;

                string login = txtLogin.Text;
                string senha = Persistence.Criptografar.MD5Hash(txtSenha.Password.ToString());

              var adminStatus = negocioUsuario.Selecionar().Where(person => person.Login == login && person.Senha == senha).Single().Admin;
              var idUser = negocioUsuario.Selecionar().Where(person => person.Login == login && person.Senha == senha).Single().Id;

            try
            {
                idAcesso = negocioAcesso.Selecionar().OrderBy(a => a.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;
            } catch (InvalidOperationException)
            {
                idAcesso = 0;
            }
                modeloUsuario.Login = login;
                modeloUsuario.Senha = senha;


                if (adminStatus == true)
                {
                    admJanela.ShowDialog();
                }
                else if (adminStatus == false)
                {

                    modeloAcesso.Id = idAcesso + 1;
                    modeloAcesso.IdUsuario = idUser;
                    modeloAcesso.Data = DateTime.Now;
                    negocioAcesso.Inserir(modeloAcesso);

                    userJanela.ShowDialog();    
                        
                }
                else { 
                MessageBox.Show("usuario nao cadastrado!");
                }
        }
    }
}
