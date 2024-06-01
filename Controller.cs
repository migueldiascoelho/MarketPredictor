using System;
using System.Collections.Generic;

namespace MarketPredictor
{
    public class Controller
    {
        private IModel model;
        private IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.model.PrevisaoAtualizada += Model_PrevisaoAtualizada;

            this.view = view;
            this.view.InicializarComponentes();
        }

        private void Model_PrevisaoAtualizada(List<Previsao> previsoes)
        {
            AtualizarPrevisoes(previsoes);
        }

        public void IniciarPrograma()
        {
            view.AtivarInterface();
        }

        public void UtilizadorClicouPrever()
        {
            try
            {
                string simboloAcao = view.ObterSimboloAcao(); // Selecionou uma acao
                model.BuscaDadosHistoricos(simboloAcao);  // Vai buscar os dados históricos para previsão
            }
            catch (Exception ex)
            {
                view.ExibirErro(ex.Message); // Mostrar mensagem de erro na interface
            }
        }

        public void AtualizarPrevisoes(List<Previsao> previsoes)
        {
            view.AtualizarPrevisoes(previsoes); // Atualiza a interface com a previsão
        }
    }
}
