using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioSeis : Window
    {
        private int contador = 0; // Variável para armazenar os clique
        public ExercicioSeis()
        {
            
            InitializeComponent();

        }
        private void btnContador_Click(object sender, RoutedEventArgs e)
        {
            contador++; // Incrementa o contador
            txtContador.Text = $"Cliques: {contador}"; // Atualiza o texto na tela
            MessageBox.Show($"Você clicou {contador} vezes!", "Contador", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }   
}
