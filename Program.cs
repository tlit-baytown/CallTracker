namespace CallTracker
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

            //Initialize Logging
            CallTracker_Lib.logging.LogInitializer.Initialize(
                CallTracker_Lib.logging.LogInitializer.GetDefaultCurrentLog());

            Application.Run(new MainForm());
        }
    }
}