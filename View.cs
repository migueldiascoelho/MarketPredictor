using MarketPredictor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarketPredictor
{
    public partial class View : Form, IView
    {
        private Controller controller;

        public View(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void InicializarComponentes()
        {
            // Símbolos das ações disponíveis para pesquisa
            comboBoxAcoes.Items.AddRange(new object[] {
                "AAPL", // Apple
                "MSFT", // Microsoft
                "GOOGL", // Alphabet (Google)
                "AMZN", // Amazon
                "META", // Facebook
                "TSLA", // Tesla
                "NFLX", // Netflix
                "NVDA", // Nvidia
                "INTC", // Intel
                "AMD", // AMD
                "IBM", // IBM
                "ORCL", // Oracle
                "CSCO", // Cisco
                "ADBE", // Adobe
                "PYPL", // PayPal
                "CRM"  // Salesforce
            });

            // Selecionar o primeiro item por padrão
            if (comboBoxAcoes.Items.Count > 0)
            {
                comboBoxAcoes.SelectedIndex = 0;
            }
        }

        public void AtivarInterface()
        {
            // Ativa a interface
            Show();
        }

        public string ObterSimboloAcao()
        {
            // Obtém o símbolo da ação selecionada
            return comboBoxAcoes.SelectedItem?.ToString();
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            // Atualiza a interface com as previsões
            if (previsoes != null && previsoes.Count > 0)
            {
                var previsao = previsoes[previsoes.Count - 1];
                labelResultado.Text = $"Preço Atual da Ação: {previsao.PrecoAtual}, Preço Previsto: {previsao.PrecoPrevisto} (próximo mês)";
            }
        }

        public void ExibirErro(string mensagem)
        {
            // Exibe a mensagem de erro na interface
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BotaoPrever_Click(object sender, EventArgs e)
        {
            controller?.UtilizadorClicouPrever();
        }
    }

    public interface IView
    {
        void InicializarComponentes();
        void AtivarInterface();
        string ObterSimboloAcao();
        void AtualizarPrevisoes(List<Previsao> previsoes);
        void ExibirErro(string mensagem);
        void SetController(Controller controller);
    }
}
