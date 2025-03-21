using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    public partial class ExercicioCinco : Window
    {
        public ExercicioCinco()
        {
            InitializeComponent();
            PreencherComboBox();
        }

        private void PreencherComboBox()
        {
            cbTipoUsuario.ItemsSource = Enum.GetValues(typeof(TipoUsuario))
                                             .Cast<TipoUsuario>()
                                             .Select(e => new { Value = e, Name = GetEnumDescription(e) });
            cbTipoUsuario.DisplayMemberPath = "Name";
            cbTipoUsuario.SelectedValuePath = "Value";
        }

        private void btnExibirDescricao_Click(object sender, RoutedEventArgs e)
        {
            if (cbTipoUsuario.SelectedValue is TipoUsuario tipoSelecionado)
            {
                string descricao = GetEnumDescription(tipoSelecionado);
                MessageBox.Show(descricao, "Descrição", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Selecione um tipo de usuário.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private string GetEnumDescription(Enum valor)
        {
            FieldInfo fi = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (atributos.Length > 0) ? atributos[0].Description : valor.ToString();
        }
    }

    public enum TipoUsuario
    {
        [Description("Usuário com permissões administrativas.")]
        Administrador,

        [Description("Usuário comum do sistema.")]
        UsuarioComum,

        [Description("Usuário visitante com acesso limitado.")]
        Visitante
    }
}
