using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task22UC : UserControl
    {
        public Task22UC()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] numbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (numbers.Length < 3)
                {
                    MessageBox.Show("Введите минимум 3 числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int lastFoundIndex = -1;

                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    if (numbers[i - 1] < numbers[i] && numbers[i] < numbers[i + 1])
                    {
                        lastFoundIndex = i;
                    }
                }

                if (lastFoundIndex != -1)
                {
                    TbResult.Text = $"Номер элемента: {lastFoundIndex}\nЗначение: {numbers[lastFoundIndex]}\n" +
                                   $"Предыдущий: {numbers[lastFoundIndex - 1]}\nСледующий: {numbers[lastFoundIndex + 1]}";
                }
                else
                {
                    TbResult.Text = "Таких элементов нет";
                }

                SpResult.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод! Используйте целые числа, разделенные пробелами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}