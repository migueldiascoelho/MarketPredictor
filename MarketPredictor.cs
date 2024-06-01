using System;

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
            IModel model = new Model();
            Controller controller = null;
            IView view = new View(controller);
            controller = new Controller(model, view);
            ((View)view).SetController(controller);
            controller.IniciarPrograma();
        }
    }
}