using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioUm.xaml
    /// </summary>
    public partial class ExercicioDois : Window
    {
        public ExercicioDois()
        {
            InitializeComponent();
        }

        private void btnSomar_Click(object sender, RoutedEventArgs e)
        {
            // Removendo espaços em branco
            string valorUmTexto = txtValorUm.Text.Trim();
            string valorDoisTexto = txtValorDois.Text.Trim();

            // Verifica se os campos estão vazios
            if (string.IsNullOrEmpty(valorUmTexto) || string.IsNullOrEmpty(valorDoisTexto))
            {
                MessageBox.Show("Por favor, preencha ambos os campos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tenta converter os valores
            if (int.TryParse(valorUmTexto, out int valorUm) && int.TryParse(valorDoisTexto, out int valorDois))
            {
                int resultado = valorUm + valorDois;
                MessageBox.Show($"Resultado: {resultado}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Digite apenas números inteiros válidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
