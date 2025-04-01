using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task21UC : UserControl
    {
        public Task21UC()
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

                if (numbers.Length == 0)
                {
                    MessageBox.Show("Введите хотя бы одно число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                System.Collections.Generic.List<int> indices = new System.Collections.Generic.List<int>();

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    bool isGreater = true;
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] <= numbers[j])
                        {
                            isGreater = false;
                            break;
                        }
                    }
                    if (isGreater)
                    {
                        indices.Add(i);
                    }
                }

                indices.Add(numbers.Length - 1);

                TbIndices.Text = $"Индексы: {string.Join(", ", indices)}";
                TbCount.Text = $"Количество: {indices.Count}";
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