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
            AtualizarPrevisoes(ref previsoes);
        }

        public void IniciarPrograma()
        {
            view.AtivarInterface();
        }

        public void UtilizadorClicouPrever()
        {
            string simboloAcao = view.ObterSimboloAcao(); // Selecionou uma acao
            model.BuscaDadosHistoricos(simboloAcao);  // Vai buscar os dados historicos para previsao
        }

        public void AtualizarPrevisoes(ref List<Previsao> previsoes)
        {
            view.AtualizarPrevisoes(previsoes); // Atualiza o interface com a previsão
        }
    }
}

