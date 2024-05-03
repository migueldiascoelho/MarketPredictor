using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarketPredictor
{
    public partial class View : Form
    {
        private Controller controller;
        private List<Previsao> previsoes;

        public View(Controller controlador)
        {
            this.controller = controlador;
            InitializeComponent();
        }

        public void InicializarComponentes()
        {
            // Configuração inicial dos componentes da UI, como botões, campos de texto, etc.
        }

        public void AtivarInterface()
        {
            // Mostra a interface principal ao usuário
            Show();
        }

        public string ObterSimboloAcao()
        {
            return "AAPL";  // Exemplo de simbolo de ação da "Apple"
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            this.previsoes = previsoes;
            // Atualizar a interface com as novas previsões
        }

        public void ExibirErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BotaoPrever_Click(object sender, EventArgs e)
        {
            controller.UtilizadorClicouPrever();
        }
    }
}
