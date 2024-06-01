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
            // Inicializa os componentes da interface
        }

        public void AtivarInterface()
        {
            // Ativa a interface
            Show();
        }

        public string ObterSimboloAcao()
        {
            // Obtém o símbolo da ação selecionada
            return "AAPL"; // Exemplo fixo, deve ser implementado conforme necessário
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            // Atualiza a interface com as previsões
        }

        public void ExibirErro(string mensagem)
        {
            // Exibe a mensagem de erro na interface
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BotaoPrever_Click(object sender, EventArgs e)
        {
            controller.UtilizadorClicouPrever();
        }
    }

    public interface IView
    {
        void InicializarComponentes();
        void AtivarInterface();
        string ObterSimboloAcao();
        void AtualizarPrevisoes(List<Previsao> previsoes);
        void ExibirErro(string mensagem);
    }
}