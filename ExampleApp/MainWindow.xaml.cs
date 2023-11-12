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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Title = "Hello to all";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        //выход из программы
        private void exitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //сохранение файла
        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }
        //создание файла
        private void createNewFile_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text != "")
            {
                saveToFile();
            }
            textBox.Text = "";
        }
        //функция сохранения
        private void saveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            bool? res = sfd.ShowDialog();
            if (res != false)
            {
                using (Stream s = File.Open(sfd.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(textBox.Text);
                    }
                }
            }
        }
        //открытие файла
        private void openNewFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? res = ofd.ShowDialog();
            if (res != false)
            {
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string file_name = ofd.FileName;
                    string file_text = File.ReadAllText(file_name);
                    textBox.Text = file_text;
                }
            }
        }
        //установка шрифта Times New Roman
        private void timesNewRoman_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times New Roman");
            verdanaFont.IsChecked = false;
        }
        //установка шрифта Verdana
        private void verdanaFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");
            timesNewRoman.IsChecked = false;
        }
        //изменение размера шрифта
        private void selectFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontsize = selectFontSize.SelectedItem.ToString();
            fontsize = fontsize.Substring(fontsize.Length - 2);
            switch (fontsize)
            {
                case "10":
                    textBox.FontSize = 10;
                    break;
                case "14":
                    textBox.FontSize = 14;
                    break;
                case "16":
                    textBox.FontSize = 16;
                    break;
                case "20":
                    textBox.FontSize = 20;
                    break;
                case "24":
                    textBox.FontSize = 24;
                    break;
                case "32":
                    textBox.FontSize = 32;
                    break;
                case "48":
                    textBox.FontSize = 48;
                    break;

            }
        }
    }
}
