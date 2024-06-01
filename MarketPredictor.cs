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
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cria o controlador
            Controller controller = new Controller();
            //controller.IniciarPrograma();
            // Cria a vista passando o controlador
            View view = new View(controller);

            // Define o formulário principal e inicia a aplicação
            Application.Run(view);
        }
    }
}
