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
            labelSelecionarAcao = new Label();
            comboBoxAcoes = new ComboBox();
            buttonPrever = new Button();
            labelResultado = new Label();
            SuspendLayout();
            // 
            // labelSelecionarAcao
            // 
            labelSelecionarAcao.AutoSize = true;
            labelSelecionarAcao.Location = new Point(229, 24);
            labelSelecionarAcao.Name = "labelSelecionarAcao";
            labelSelecionarAcao.Size = new Size(91, 15);
            labelSelecionarAcao.TabIndex = 0;
            labelSelecionarAcao.Text = "Selecionar Ação";
            // 
            // comboBoxAcoes
            // 
            comboBoxAcoes.FormattingEnabled = true;
            comboBoxAcoes.Items.AddRange(new object[] { "AAPL" });
            comboBoxAcoes.Location = new Point(170, 42);
            comboBoxAcoes.Name = "comboBoxAcoes";
            comboBoxAcoes.Size = new Size(150, 23);
            comboBoxAcoes.TabIndex = 1;
            // 
            // buttonPrever
            // 
            buttonPrever.Location = new Point(326, 42);
            buttonPrever.Name = "buttonPrever";
            buttonPrever.Size = new Size(75, 23);
            buttonPrever.TabIndex = 2;
            buttonPrever.Text = "Prever";
            buttonPrever.UseVisualStyleBackColor = true;
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Location = new Point(244, 133);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(334, 15);
            labelResultado.TabIndex = 3;
            labelResultado.Text = "Ainda não temos estes dados, mas estamos a trabalhar nisso...";
            // 
            // View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelSelecionarAcao);
            Controls.Add(comboBoxAcoes);
            Controls.Add(buttonPrever);
            Controls.Add(labelResultado);
            Name = "View";
            Text = "Market Predictor";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
