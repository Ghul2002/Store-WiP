using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Store
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Files file = new Files();
        public Window1()
        {
            InitializeComponent();
            if (File.Exists(file.file1) && File.Exists(file.file2))
            {
                StreamReader ReadFile1 = new StreamReader(file.file1);
                string line;
                while ((line = ReadFile1.ReadLine()) != null)
                {
                    Code.Items.Add(line);
                }
                StreamReader ReadFile2 = new StreamReader(file.file2);
                while ((line = ReadFile2.ReadLine()) != null)
                {
                    Quantity.Items.Add(line);
                }
                StreamReader ReadFile3 = new StreamReader(file.file3);
                while ((line = ReadFile3.ReadLine()) != null)
                {
                    Name.Items.Add(line);
                }
                StreamReader ReadFile4 = new StreamReader(file.file4);
                while ((line = ReadFile4.ReadLine()) != null)
                {
                    Category.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Warehouse empty!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
