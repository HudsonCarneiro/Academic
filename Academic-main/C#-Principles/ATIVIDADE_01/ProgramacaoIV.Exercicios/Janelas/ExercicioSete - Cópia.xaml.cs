using System;
using System.Windows;
using System.Windows.Controls;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioSete : Window
    {
        public ExercicioSete()
        {
            InitializeComponent();
        }

        private void btnCalcularParcela_Click(object sender, RoutedEventArgs e)
        {
            // Remove espaços em branco e valida o valor inserido
            string valorTotalTexto = txtValorTotal.Text.Trim();

            if (string.IsNullOrEmpty(valorTotalTexto))
            {
                MessageBox.Show("Por favor, insira um valor total.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(valorTotalTexto, out double valorTotal) || valorTotal <= 0)
            {
                MessageBox.Show("Digite um valor total válido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verifica se o usuário selecionou uma parcela
            if (cbParcelas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione a quantidade de parcelas.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Obtém o número de parcelas

            int numeroParcelas = int.Parse(((ComboBoxItem)cbParcelas.SelectedItem).Content.ToString());


            // Calcula o valor da parcela
            double valorParcela = valorTotal / numeroParcelas;

            // Exibe o resultado
            MessageBox.Show($"Valor de cada parcela: R$ {valorParcela:F2}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
