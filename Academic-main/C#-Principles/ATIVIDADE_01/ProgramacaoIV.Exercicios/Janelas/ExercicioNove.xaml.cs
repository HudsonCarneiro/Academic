using System;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioNove : Window
    {
        private bool estadoLigado = false;

        public ExercicioNove()
        {
            InitializeComponent();
        }

        private void btnInterruptor_Click(object sender, RoutedEventArgs e)
        {
            estadoLigado = !estadoLigado;
            if (estadoLigado)
            {
                btnInterruptor.Content = "Ligado";
              
            }
            else
            {
                btnInterruptor.Content = "Desligado";
           

            }
              
        }
    }
}
