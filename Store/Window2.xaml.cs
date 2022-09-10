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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Files file = new Files();
        public static bool added;
        public Window2()
        {
            InitializeComponent();
            Category.Items.Add("-");
            StreamReader ReadFile = new StreamReader("category_name.txt");
            string line;
            while ((line = ReadFile.ReadLine()) != null)
            {
                Category.Items.Add(line);
            }
            Category.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text == null)
            {
                MessageBox.Show("Enter valid data!");
            }
            else
            {
                StreamWriter SaveFile3 = new StreamWriter(file.file3, append: true);
                SaveFile3.WriteLine(Name.Text);
                SaveFile3.Close();
                StreamWriter SaveFile4 = new StreamWriter(file.file4, append: true);
                SaveFile4.WriteLine(Category.SelectedItem);
                SaveFile4.Close();
                MessageBox.Show("Product Added!");
                added = true;
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
