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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;


namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Files file = new Files();

        public MainWindow()
        {
            InitializeComponent();
            for(int i=1; i<=100; i++)
            {
                Quantity.Items.Add(i);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text.Length == 12)
            {
                bool match = false;
                if (File.Exists(file.file1))
                {
                    string[] lines1 = File.ReadAllLines(file.file1);
                    for (int i = 0; i < lines1.Length; i++)
                    {
                        if (lines1[i] == Code.Text)
                        {
                            string[] lines2 = File.ReadAllLines(file.file2);
                            int sum = Convert.ToInt32(lines2[i]) + Convert.ToInt32(Quantity.SelectedIndex);
                            lines2[i] = sum.ToString();
                            File.WriteAllLines(file.file2, lines2);
                            match = true;
                        }
                    }
                }
                if (!match)
                {
                    Window2 win2 = new Window2();
                    win2.Show();
                        StreamWriter SaveFile1 = new StreamWriter(file.file1, append: true);
                        SaveFile1.WriteLine(Code.Text);
                        SaveFile1.Close();
                        StreamWriter SaveFile2 = new StreamWriter(file.file2, append: true);
                        SaveFile2.WriteLine(Quantity.SelectedIndex);
                        SaveFile2.Close();
                }
                Code.Clear();
                Quantity.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Insert valid product code!");
            }

        }
        private void Warehouse_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }

        private void Selling_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            File.Delete(file.file1);
            File.Delete(file.file2);
            File.Delete(file.file3);
            File.Delete(file.file4);
        }

        private void Add_Category_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
        }
    }

}
