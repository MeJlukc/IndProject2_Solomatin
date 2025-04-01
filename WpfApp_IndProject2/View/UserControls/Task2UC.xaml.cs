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

namespace WpfApp_IndProject2.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task2UC.xaml
    /// </summary>
    public partial class Task2UC : UserControl
    {
        #region Исходные данные
        private int _a;
        private int _b;
        #endregion

        public Task2UC()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            Random random = new();
            _a = random.Next(10, 100);
            _b = random.Next(10, 100);

            TbA.Text = _a.ToString();
            TbB.Text = _b.ToString();
        }

        private int Nod(int value1, int value2)
        {
            int b = 1;
            int q = value1 < value2 ? value1 : value2;
            int r = 0;
            int a = value1 < value2 ? value2 : value1;
            do
            {
                while (a - (b * q) >= q)
                {
                    b++;
                }
                r = a - (b * q);
                a = q;
                q = r;
            }
            while (r > 0);
            return a;
        }
        private void BtnGetAnswer_Click(object sender, RoutedEventArgs e)
        {
            int a = _a / Nod(Nod(_a, _b), _a);
            int b = _b / Nod(Nod(_a, _b), _b);

            MessageBox.Show($"{a} / {b}",
                "Ответ к заданию 2",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

    }
}
