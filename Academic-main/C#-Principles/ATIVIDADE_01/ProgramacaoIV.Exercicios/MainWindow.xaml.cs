using ProgramacaoIV.Exercicios.Janelas;
using System.Windows;

namespace ProgramacaoIV.Exercicios;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnExercicioUm_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioUm().ShowDialog();
    }
    private void btnExercicioDois_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioDois().ShowDialog();
    }
}