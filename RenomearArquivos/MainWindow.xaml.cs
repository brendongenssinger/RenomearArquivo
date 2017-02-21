using System.Windows;
using System.Windows.Forms;
using RenomearArquivos.Model;

namespace RenomearArquivos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        _Configuration conf = new _Configuration();
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
            { 
                caminho = folder.SelectedPath;
                converter.Converter(caminho);
            }

           if(conf.mensagemError==null)
            {
                System.Windows.MessageBox.Show("Imagens Convertidas.");
                txtCaminho.Text = "Imagens Convertidas";
            }
           else
            {
                txtCaminho.Text = conf.mensagemError;
            }
        }
    }
}
