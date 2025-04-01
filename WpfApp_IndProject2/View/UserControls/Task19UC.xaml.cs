using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task19UC : UserControl
    {
        public Task19UC()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] numbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (numbers.Length < 2)
                {
                    MessageBox.Show("Введите хотя бы 2 числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int difference = numbers[1] - numbers[0];
                bool isArithmetic = true;

                for (int i = 2; i < numbers.Length; i++)
                {
                    if (numbers[i] - numbers[i - 1] != difference)
                    {
                        isArithmetic = false;
                        break;
                    }
                }

                TbResult.Text = isArithmetic
                    ? $"Да, разность прогрессии: {difference}"
                    : "Не образуют арифметическую прогрессию";

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