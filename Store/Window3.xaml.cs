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
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            bool match = false;
            if (File.Exists("category_name.txt"))
            {
                string[] lines1 = File.ReadAllLines("category_name.txt");
                for (int i = 0; i < lines1.Length; i++)
                {
                    if (lines1[i] == category_name.Text)
                    {
                        MessageBox.Show("Category already exist!");
                        category_name.Clear();
                        match = true;
                    }
                }
            }
            if (!match)
            {
                StreamWriter SaveFile3 = new StreamWriter("category_name.txt", append: true);
                SaveFile3.WriteLine(category_name.Text);
                SaveFile3.Close();
                MessageBox.Show("Category added!");
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
