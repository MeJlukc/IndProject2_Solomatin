using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task9UC : UserControl
    {
        public Task9UC()
        {
            InitializeComponent();
        }

        private void BtnCompare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;

                if (!double.TryParse(TbSquareSide.Text, out double squareSide) || squareSide <= 0)
                {
                    MessageBox.Show("Введите корректную длину стороны квадрата!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!double.TryParse(TbCircleRadius.Text, out double circleRadius) || circleRadius <= 0)
                {
                    MessageBox.Show("Введите корректный радиус круга!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double squareArea = Math.Pow(squareSide, 2);
                double circleArea = Math.PI * Math.Pow(circleRadius, 2);

                string result;
                if (Math.Abs(squareArea - circleArea) < 0.0001)
                {
                    result = "Площади равны!";
                }
                else if (squareArea > circleArea)
                {
                    result = "Площадь квадрата больше!";
                }
                else
                {
                    result = "Площадь круга больше!";
                }

                TbSquareArea.Text = squareArea.ToString("F4");
                TbCircleArea.Text = circleArea.ToString("F4");
                TbComparisonResult.Text = result;

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчетах: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}