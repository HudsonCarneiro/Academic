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

    private void btnExercicioTres_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioTres().ShowDialog();
    }

    private void btnExercicioQuatro_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioQuatro().ShowDialog();
    }

    private void btnExercicioCinco_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioCinco().ShowDialog();
    }

    private void btnExercicioSeis_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioSeis().ShowDialog();
    }

    private void btnExercicioSete_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioSete().ShowDialog();
    }

    private void btnExercicioDez_Click(object sender, RoutedEventArgs e)
    {
        new ExercicioOito().ShowDialog();
    }

    private void btnExercicioNove_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnExercicioOito_Click(object sender, RoutedEventArgs e)
    {

    }
}