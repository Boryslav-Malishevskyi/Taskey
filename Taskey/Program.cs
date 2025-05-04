using Presenter;

namespace Taskey
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var form = new Taskey();
            var view = new View(form);
            var presenter = new PresenterController(view);
            Application.Run(form);
        }
    }
}