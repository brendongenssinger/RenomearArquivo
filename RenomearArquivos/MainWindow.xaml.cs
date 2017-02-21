using System.Windows;
using System.Windows.Forms;

namespace RenomearArquivos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FolderBrowserDialog folder = new FolderBrowserDialog();
        _Converter converter = new _Converter();
        string caminho;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
          
           if(folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            caminho = folder.SelectedPath;
            converter.Converter(caminho);
        }
    }
}
