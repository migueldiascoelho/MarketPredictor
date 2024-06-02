namespace MarketPredictor
{
    partial class View
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelSelecionarAcao;
        private System.Windows.Forms.ComboBox comboBoxAcoes;
        private System.Windows.Forms.Button buttonPrever;
        private System.Windows.Forms.Label labelResultado;

        /// <summary>
        /// Limpa quaisquer recursos que estão a ser usados.
        /// </summary>
        /// <param name="disposing">true se os recursos geridos devem ser descartados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método necessário para o suporte ao Designer - não modifique
        /// os conteúdos deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSelecionarAcao = new System.Windows.Forms.Label();
            this.comboBoxAcoes = new System.Windows.Forms.ComboBox();
            this.buttonPrever = new System.Windows.Forms.Button();
            this.labelResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // labelSelecionarAcao
            // 
            this.labelSelecionarAcao.AutoSize = true;
            this.labelSelecionarAcao.Location = new System.Drawing.Point(20, 20);
            this.labelSelecionarAcao.Name = "labelSelecionarAcao";
            this.labelSelecionarAcao.Size = new System.Drawing.Size(95, 15);
            this.labelSelecionarAcao.TabIndex = 0;
            this.labelSelecionarAcao.Text = "Selecionar Ação Cotada em Bolsa e clicar em Prever para ter uma previsão do seu valor futuro";

            // 
            // comboBoxAcoes
            // 
            this.comboBoxAcoes.FormattingEnabled = true;
            this.comboBoxAcoes.Location = new System.Drawing.Point(20, 50);
            this.comboBoxAcoes.Name = "comboBoxAcoes";
            this.comboBoxAcoes.Size = new System.Drawing.Size(150, 23);
            this.comboBoxAcoes.TabIndex = 1;

            // 
            // buttonPrever
            // 
            this.buttonPrever.Location = new System.Drawing.Point(20, 90);
            this.buttonPrever.Name = "buttonPrever";
            this.buttonPrever.Size = new System.Drawing.Size(75, 23);
            this.buttonPrever.TabIndex = 2;
            this.buttonPrever.Text = "Prever";
            this.buttonPrever.UseVisualStyleBackColor = true;
            this.buttonPrever.Click += new System.EventHandler(this.BotaoPrever_Click);

            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(200, 50);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(248, 15);
            this.labelResultado.TabIndex = 3;

            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSelecionarAcao);
            this.Controls.Add(this.comboBoxAcoes);
            this.Controls.Add(this.buttonPrever);
            this.Controls.Add(this.labelResultado);
            this.Name = "View";
            this.Text = "Market Predictor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
