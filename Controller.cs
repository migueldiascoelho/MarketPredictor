using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarketPredictor
{
    public class Controller
    {
        private Model model;
        private View view;

        public Controller()
        {
            model = new Model();
            model.PrevisaoAtualizada += Model_PrevisaoAtualizada;

            view = new View(this);
            view.InicializarComponentes();
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

