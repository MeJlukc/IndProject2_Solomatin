using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task20UC : UserControl
    {
        public Task20UC()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] numbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (numbers.Length < 2)
                {
                    MessageBox.Show("Введите хотя бы 2 числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (numbers.Contains(0))
                {
                    TbResult.Text = "Последовательность с нулями не может быть геометрической прогрессией";
                    SpResult.Visibility = Visibility.Visible;
                    return;
                }

                double ratio = numbers[1] / numbers[0];
                bool isGeometric = true;

                for (int i = 2; i < numbers.Length; i++)
                {
                    if (Math.Abs(numbers[i] / numbers[i - 1] - ratio) > 0.0001)
                    {
                        isGeometric = false;
                        break;
                    }
                }

                TbResult.Text = isGeometric
                    ? $"Да, знаменатель прогрессии: {ratio:F2}"
                    : "Не образуют геометрическую прогрессию";

                SpResult.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод! Используйте числа, разделенные пробелами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}