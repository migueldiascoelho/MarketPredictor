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
            Controller controller = new Controller();
            controller.IniciarPrograma();
        }
    }
}
