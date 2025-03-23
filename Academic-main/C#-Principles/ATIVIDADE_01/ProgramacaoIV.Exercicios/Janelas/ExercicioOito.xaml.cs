using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioOito : Window
    {
        public ExercicioOito()
        {
            InitializeComponent();
        }

        // Enum dos dias da semana
        public enum DiasDaSemana
        {
            Domingo, Segunda, Terça, Quarta, Quinta, Sexta, Sábado
        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se o usuário selecionou uma data
            if (dtpData.SelectedDate == null)
            {
                MessageBox.Show("Por favor, selecione uma data.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Obtém a data selecionada
            DateTime dataSelecionada = dtpData.SelectedDate.Value;

            // Converte para o enum correspondente
            DiasDaSemana diaSemana = (DiasDaSemana)dataSelecionada.DayOfWeek;

            // Exibe o dia da semana
            MessageBox.Show($"O dia selecionado é: {diaSemana}", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
