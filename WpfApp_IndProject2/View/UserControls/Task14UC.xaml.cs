using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task14UC : UserControl
    {
        public Task14UC()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = TbInputArray.Text.Trim();
                string[] binaryNumbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (binaryNumbers.Length != 5)
                {
                    MessageBox.Show("Пожалуйста, введите ровно 5 двоичных чисел, разделенных пробелами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                foreach (string num in binaryNumbers)
                {
                    if (!IsBinary(num))
                    {
                        MessageBox.Show($"Число '{num}' не является двоичным.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                var sortedArray = binaryNumbers.OrderByDescending(x => x).ToArray();

                int sum = 0;
                foreach (string binary in binaryNumbers)
                {
                    sum += Convert.ToInt32(binary, 2);
                }

                TbSortedArray.Text = string.Join(" ", sortedArray);
                TbSum.Text = $"{sum} (в двоичной: {Convert.ToString(sum, 2)})";

                SpSortedArray.Visibility = Visibility.Visible;
                SpSum.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsBinary(string number)
        {
            foreach (char c in number)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }
    }
}