using System;
using System.Threading;
using System.Windows;

namespace ReelApp
{
    public partial class App : Application
    {
        // Mutex garante que apenas uma instância do Reel rode no Windows
        private static Mutex? _mutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "ReelApp_SingleInstance_Mutex";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                // Se o app já estiver aberto, avisa e fecha o novo processo
                MessageBox.Show("O Reel já está em execução (veja na bandeja do sistema).", "Reel", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Libera a memória ao fechar
            if (_mutex != null)
            {
                _mutex.ReleaseMutex();
                _mutex.Dispose();
            }
            base.OnExit(e);
        }
    }
}