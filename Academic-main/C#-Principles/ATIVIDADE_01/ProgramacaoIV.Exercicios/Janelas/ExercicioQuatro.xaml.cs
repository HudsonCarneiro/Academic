using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioTres.xaml
    /// </summary>
    public partial class ExercicioQuatro : Window
    {
        public ExercicioQuatro()
        {
            InitializeComponent();
        }

        private void btnCalcMaiorIdade_Click(object sender, RoutedEventArgs e)
        {
            string idadeTexto = txtIdade.Text.Trim();

            // Verifica se o campo está vazio
            if (string.IsNullOrEmpty(idadeTexto))
            {
                MessageBox.Show("Por favor, insira sua idade.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Converte para número e verifica a maioridade
            if (int.TryParse(idadeTexto, out int idade))
            {
                string resultado = idade >= 18 ? "Maior de idade" : "Menor de idade";
                MessageBox.Show($"Você é {resultado}!", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Digite um número válido para a idade.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
