using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task16UC : UserControl
    {
        public Task16UC()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var numbers = TbInputArray.Text.Split(' ')
                    .Select(double.Parse)
                    .ToArray();

                if (numbers.Length != 12)
                {
                    MessageBox.Show("Введите ровно 12 чисел!");
                    return;
                }

                int maxIndex = Array.IndexOf(numbers, numbers.Max());
                int minIndex = Array.IndexOf(numbers, numbers.Min());

                int count = Math.Abs(maxIndex - minIndex) - 1;
                TbResult.Text = $"Между max и min: {count} чисел";
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}