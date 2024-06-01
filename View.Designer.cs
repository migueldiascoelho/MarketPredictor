namespace MarketPredictor
{
    partial class View
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelSelecionarAcao;
        private System.Windows.Forms.ComboBox comboBoxAcoes;
        private System.Windows.Forms.Button BotaoPrever;
        private System.Windows.Forms.Label labelResultado;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSelecionarAcao = new System.Windows.Forms.Label();
            this.comboBoxAcoes = new System.Windows.Forms.ComboBox();
            this.BotaoPrever = new System.Windows.Forms.Button();
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
            this.labelSelecionarAcao.Text = "Selecionar Ação";

            // 
            // comboBoxAcoes
            // 
            this.comboBoxAcoes.FormattingEnabled = true;
            this.comboBoxAcoes.Items.AddRange(new object[] { "AAPL" });
            this.comboBoxAcoes.Location = new System.Drawing.Point(20, 50);
            this.comboBoxAcoes.Name = "comboBoxAcoes";
            this.comboBoxAcoes.Size = new System.Drawing.Size(150, 23);
            this.comboBoxAcoes.TabIndex = 1;

            // 
            // botãoPrever
            // 
            this.BotaoPrever.Location = new System.Drawing.Point(20, 90);
            this.BotaoPrever.Name = "BotaoPrever";
            this.BotaoPrever.Size = new System.Drawing.Size(75, 23);
            this.BotaoPrever.TabIndex = 2;
            this.BotaoPrever.Text = "Prever";
            this.BotaoPrever.UseVisualStyleBackColor = true;
            this.BotaoPrever.Click += new System.EventHandler(this.BotaoPrever_Click);

            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(200, 50);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(248, 15);
            this.labelResultado.TabIndex = 3;
            this.labelResultado.Text = "Ainda não temos estes dados, mas estamos a trabalhar nisso...";

            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSelecionarAcao);
            this.Controls.Add(this.comboBoxAcoes);
            this.Controls.Add(this.BotaoPrever);
            this.Controls.Add(this.labelResultado);
            this.Name = "View";
            this.Text = "Market Predictor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
