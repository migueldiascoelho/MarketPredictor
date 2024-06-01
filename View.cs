using MarketPredictor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarketPredictor
{
    public partial class View : Form, IView
    {
        private Controller controller;
        private List<Previsao> previsoes;
        private TextBox textBoxSymbol;
        private Button buttonPredict;
        private ListBox listBoxPrevisoes;

        public View()
        {
            InitializeComponent();  // Inicialização básica
        }
        public View(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            InicializarComponentes();

            // Adiciona o manipulador de eventos para o fecho do formulário
            this.FormClosing += new FormClosingEventHandler(View_FormClosing);
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void InicializarComponentes()
        {
            // Configuração inicial dos componentes da UI, como botões, campos de texto, etc.
            this.textBoxSymbol = new TextBox();
            this.textBoxSymbol.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(this.textBoxSymbol);

            this.buttonPredict = new Button();
            this.buttonPredict.Text = "Prever";
            this.buttonPredict.Location = new System.Drawing.Point(70, 60);
            this.buttonPredict.Click += new EventHandler(this.BotaoPrever_Click);
            this.Controls.Add(this.buttonPredict);

            this.listBoxPrevisoes = new ListBox();
            this.listBoxPrevisoes.Location = new System.Drawing.Point(20, 100);
            this.Controls.Add(this.listBoxPrevisoes);

            if (this.comboBoxAcoes == null)
            {
                this.comboBoxAcoes = new ComboBox();
                this.comboBoxAcoes.Location = new System.Drawing.Point(150, 20);
                this.Controls.Add(this.comboBoxAcoes);
            }

            if (this.labelResultado == null)
            {
                this.labelResultado = new Label();
                this.labelResultado.Location = new System.Drawing.Point(20, 200);
                this.Controls.Add(this.labelResultado);
            }

            // Adicionar mais símbolos de ações ao comboBoxAcoes
            comboBoxAcoes.Items.AddRange(new object[] {
                "AAPL", // Apple
                "MSFT", // Microsoft
                "GOOGL", // Alphabet (Google)
                "AMZN", // Amazon
                "META", // Facebook
                "TSLA" // Tesla
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
            // Retorna o símbolo de ação selecionado no comboBoxAcoes
            return comboBoxAcoes.SelectedItem?.ToString();
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            this.previsoes = previsoes;
            // Atualizar a interface com as novas previsões
            listBoxPrevisoes.Items.Clear();
            foreach (var previsao in previsoes)
            {
                listBoxPrevisoes.Items.Add(previsao.ToString());
            }

            // Atualiza a interface com a previsão mais recente
            if (previsoes != null && previsoes.Count > 0)
            {
                var previsao = previsoes[previsoes.Count - 1];
              //  labelResultado.Text = $"Preço Atual da Ação: {previsao.PrecoPrevisto}";
            }
            else
            {
                labelResultado.Text = "Ainda não temos estes dados, mas estamos a trabalhar nisso...";
            }
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

        // Manipulador de eventos para o fecho do formulário
        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exibe uma mensagem de confirmação ao usuário
            var result = MessageBox.Show("Deseja encerrar o programa e sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Cancela o fecho do formulário
                e.Cancel = true;
            }
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
