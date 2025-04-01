using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task27UC : UserControl
    {
        public Task27UC()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double[] numbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (numbers.Length == 0)
                {
                    MessageBox.Show("Введите хотя бы одно число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(TbRValue.Text, out double rValue))
                {
                    MessageBox.Show("Введите корректное число R!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var closest = numbers
                    .Select((value, index) => new
                    {
                        Value = value,
                        Index = index,
                        Difference = Math.Abs(value - rValue)
                    })
                    .OrderBy(x => x.Difference)
                    .First();

                TbClosestElement.Text = $"Ближайший элемент: {closest.Value}\n" +
                                      $"Индекс: {closest.Index}\n" +
                                      $"Разница с R: {closest.Difference:F4}";

                SpResult.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат чисел в массиве!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}