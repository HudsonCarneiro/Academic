using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioTres.xaml
    /// </summary>
    public partial class ExercicioTres : Window
    {
        public ExercicioTres()
        {
            InitializeComponent();
        }

        private void btnCalcProxAniversario_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se a data foi selecionada
            if (dtpNascimento.SelectedDate == null)
            {
                MessageBox.Show("Por favor, selecione sua data de nascimento.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Obtém a data de nascimento
            DateTime dataNascimento = dtpNascimento.SelectedDate.Value;

            // Obtém a data atual
            DateTime hoje = DateTime.Today;
            DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

            // Se já passou, calcula para o próximo ano
            if (proximoAniversario < hoje)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }

            int diasFaltantes = (proximoAniversario - hoje).Days;

            MessageBox.Show($"Faltam {diasFaltantes} dias para seu próximo aniversário!", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
