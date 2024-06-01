using System;
using System.Windows.Forms;

namespace MarketPredictor
{
    class MarketPredictor
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cria inst�ncias do Model e do Controller
            IModel model = new Model();
            IView view = new View(); // A View precisa ser inicializada sem o controlador
            Controller controller = new Controller(model, view);

            // Define o controlador para a vista
            view.SetController(controller);

            // Define o formul�rio principal e inicia a aplica��o
            Application.Run((Form)view);
        }
    }
}
