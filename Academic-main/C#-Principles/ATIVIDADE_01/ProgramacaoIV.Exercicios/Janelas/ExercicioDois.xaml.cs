using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioDois.xaml
    /// </summary>
    public partial class ExercicioDois : Window
    {
        public ExercicioDois()
        {
            InitializeComponent();
        }

        private void btnConverterEmFahrenheit_Click(object sender, RoutedEventArgs e)
        {
            // Remove espaços em branco antes da conversão
            string valorCelsiusTexto = txtValorCelsius.Text.Trim();

            // Verifica se o campo está vazio
            if (string.IsNullOrEmpty(valorCelsiusTexto))
            {
                MessageBox.Show("Por favor, insira um valor em Celsius.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Converte o valor para double e realiza o cálculo
            if (double.TryParse(valorCelsiusTexto, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                MessageBox.Show($"{celsius}°C equivale a {fahrenheit:F2}°F", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Digite um número válido para a temperatura.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
