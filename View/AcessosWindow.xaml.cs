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
    /// Lógica interna para AcessosWindow.xaml
    /// </summary>
    public partial class AcessosWindow : Window
    {
        public AcessosWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            updateGrid();
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

        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataLog = DateTime.Parse(textData.Text);
            var users = negocioAcessos.Selecionar().Where(person => person.Data == dataLog).ToList();
            updateGrid();
        }
    }
}
