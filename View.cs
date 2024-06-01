using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarketPredictor
{
    public partial class View : Form
    {
        private Controller controller;
        private List<Previsao> previsoes;
        private TextBox textBoxSymbol;      
        private Button buttonPredict;       // bot�o para previs�o
        private ListBox listBoxPrevisoes;

        public View(Controller controlador)
        {
            this.controller = controlador;
            InitializeComponent();
            InicializarComponentes();

            // Adiciona o manipulador de eventos para o fecho do formulario
            this.FormClosing += new FormClosingEventHandler(View_FormClosing);
        }

        public void InicializarComponentes()
        { // Configura��o inicial dos componentes da UI, como bot�es, campos de texto, etc.
            this.textBoxSymbol = new TextBox();
            this.textBoxSymbol.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(this.textBoxSymbol);

            this.buttonPredict = new Button();
            this.buttonPredict.Text = "Prever";
            this.buttonPredict.Location = new System.Drawing.Point(20, 60);
            this.buttonPredict.Click += new EventHandler(this.BotaoPrever_Click);
            this.Controls.Add(this.buttonPredict);

            this.listBoxPrevisoes = new ListBox();
            this.listBoxPrevisoes.Location = new System.Drawing.Point(20, 100);
            this.Controls.Add(this.listBoxPrevisoes);
        }

        public void AtivarInterface()
        {
            // Mostra a interface principal ao usu�rio
            Show();
        }

        public string ObterSimboloAcao()
        {
            return textBoxSymbol.Text;  // retorna o simbolo de ac��o exemplo "APPL"
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            this.previsoes = previsoes;
            // Atualizar a interface com as novas previs�es
            listBoxPrevisoes.Items.Clear();
            foreach (var previsao in previsoes)
            {
                listBoxPrevisoes.Items.Add(previsao.ToString());
            }
        }

        public void ExibirErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BotaoPrever_Click(object sender, EventArgs e)
        {
            controller.UtilizadorClicouPrever();
        }

        // Manipulador de eventos para o fecho do formul�rio
        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exibe uma mensagem de confirma��o ao usu�rio
            var result = MessageBox.Show("Deseja encerrar o programa e sair?", "Confirma��o", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Cancela o fecho do formul�rio
                e.Cancel = true;
            }
        }
    }
}
