using Microsoft.Maui.Controls;
using System;

namespace CalculadoraUnivesp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            try
            {
                bool isNotaProvaEmpty = string.IsNullOrEmpty(notaProva.Text);
                bool isNotaAtividadeEmpty = string.IsNullOrEmpty(notaAtividade.Text);

                if (isNotaProvaEmpty && isNotaAtividadeEmpty)
                {
                    resultadoLabel.Text = "Por favor, insira pelo menos uma das notas.";
                    return;
                }

                double notaProvaValue = isNotaProvaEmpty ? 0 : double.Parse(notaProva.Text);
                double notaAtividadeValue = isNotaAtividadeEmpty ? 0 : double.Parse(notaAtividade.Text);

                // Cálculo da média final
                double mediaFinal = (0.6 * notaProvaValue) + (0.4 * notaAtividadeValue);

                // Verificação da nota mínima para aprovação e sugestão de nota
                if (isNotaProvaEmpty)
                {
                    double notaProvaNecessaria = (5 - (0.4 * notaAtividadeValue)) / 0.6;
                    resultadoLabel.Text = $"Você precisa tirar {notaProvaNecessaria:F2} na prova para alcançar a média final de 5.";
                }
                else if (isNotaAtividadeEmpty)
                {
                    double notaAtividadeNecessaria = (5 - (0.6 * notaProvaValue)) / 0.4;
                    resultadoLabel.Text = $"Você precisa tirar {notaAtividadeNecessaria:F2} na atividade avaliativa para alcançar a média final de 5.";
                }
                else
                {
                    string resultado = mediaFinal >= 5 ? "Aprovado" : "Reprovado";
                    resultadoLabel.Text = $"Média Final: {mediaFinal:F2}\nResultado: {resultado}";
                }
            }
            catch (Exception ex)
            {
                resultadoLabel.Text = $"Erro: {ex.Message}";
            }
        }
    }
}
