using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task10UC : UserControl
    {
        public Task10UC()
        {
            InitializeComponent();
        }

        private void BtnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;
                var lines = TbMatrix.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length != 5)
                {
                    MessageBox.Show("Введите ровно 5 строк!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double[,] matrix = new double[5, 6];
                for (int i = 0; i < 5; i++)
                {
                    var numbers = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (numbers.Length != 6)
                    {
                        MessageBox.Show($"В строке {i + 1} должно быть 6 чисел!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    for (int j = 0; j < 6; j++)
                    {
                        if (!double.TryParse(numbers[j], out matrix[i, j]))
                        {
                            MessageBox.Show($"Некорректное число в строке {i + 1}, позиция {j + 1}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

                string result = "";
                for (int j = 0; j < 6; j++)
                {
                    double sum = 0;
                    int count = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            sum += matrix[i, j];
                            count++;
                        }
                    }
                    double avg = count > 0 ? sum / count : 0;
                    result += $"Столбец {j + 1}: Ср.арифм. положительных = {avg:F2}\n";
                }

                TbAnalysisResult.Text = result;
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}