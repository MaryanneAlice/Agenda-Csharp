﻿using System;
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
    /// Lógica interna para AcessosWindow.xaml
    /// </summary>
    public partial class AcessosWindow : Window
    {
        public AcessosWindow()
        {
            InitializeComponent();
            addComboBOX();            
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

        Business.Acessos negocioAcessos = new Business.Acessos();

        public void addComboBOX()
        {
            admAcessosComboBox.Items.Add("Escolher");
            admAcessosComboBox.Items.Add("Id");
            admAcessosComboBox.Items.Add("Nome");
            admAcessosComboBox.SelectedItem = "Escolher";
        }

        public void updateGrid()
        {
            gridAcessosAdm.ItemsSource = null;
            gridAcessosAdm.ItemsSource = negocioAcessos.Selecionar();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            updateGrid();
        }

        private void PesquisarClick(object sender, RoutedEventArgs e)
        {
            // pesquisar
        }
    }
}
