using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_1._1_Exercise_5_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Paint(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        private void Button_Click_Erase(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ink Serialized Format (ISF)|*.isf";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    canvas.Strokes.Save(fs);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ink Serialized Format(ISF) | *.isf";

            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    StrokeCollection strokes = new StrokeCollection(fs);
                    canvas.Strokes = strokes;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }

        private void MenuItem_Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
