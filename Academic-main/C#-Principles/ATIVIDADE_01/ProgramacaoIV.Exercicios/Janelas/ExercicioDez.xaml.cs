using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioDez : Window
    {
        private Random random = new Random();

        public ExercicioDez()
        {
            InitializeComponent();
        }

        private void btnSortear_Click(object sender, RoutedEventArgs e)
        {
            int numeroSorteado = random.Next(1, 7);

            if(numeroSorteado == 6)
            {
                MessageBox.Show($"Numero sorteado : {numeroSorteado} \nVOCÊ GANHOUUU!",
                    "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Numero sorteado: {numeroSorteado} ---- Tente Novamente! :(",
                    "Resultado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }     
        }
    }
}
