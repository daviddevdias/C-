using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using YoutubeDLSharp;
using YoutubeDLSharp.Options;

namespace ReelApp
{
    public partial class MainWindow : Window
    {
        private YoutubeDL? _ytdl;

        public MainWindow()
        {
            InitializeComponent();
            ConfigurarMotor();
        }

        // Prepara o motor yt-dlp e o FFmpeg automaticamente
        private async void ConfigurarMotor()
        {
            BtnBaixar.IsEnabled = false;
            TxtStatus.Text = "Preparando motor de download (yt-dlp e ffmpeg)...";

            await YoutubeDLSharp.Utils.DownloadYtDlp();
            await YoutubeDLSharp.Utils.DownloadFFmpeg();

            _ytdl = new YoutubeDL
            {
                YoutubeDLPath = "yt-dlp.exe",
                FFmpegPath = "ffmpeg.exe",
                OutputFolder = Utils.GetDownloadsFolder()
            };

            TxtStatus.Text = $"Pronto! Salvar em: {Utils.GetDownloadsFolder()}";
            BtnBaixar.IsEnabled = true;
        }

        // AQUI ESTÁ A FUNÇÃO DE ARRASTAR A JANELA!
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

        // Lógica do botão Baixar
        private async void BtnBaixar_Click(object sender, RoutedEventArgs e)
        {
            string url = TxtUrl.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Cole um link válido primeiro!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_ytdl == null) return;

            BtnBaixar.IsEnabled = false;
            BtnBaixar.Content = "Baixando...";

            try
            {
                // TENTATIVA 1: Tenta usar os cookies do Chrome
                var options = new OptionSet()
                {
                    CookiesFromBrowser = "chrome" 
                };

                var progress = new Progress<DownloadProgress>(p => 
                {
                    TxtStatus.Text = $"Baixando... {p.Progress * 100:0.0}% (Velocidade: {p.DownloadSpeed})";
                });

                TxtStatus.Text = "Iniciando download com cookies...";
                var res = await _ytdl.RunVideoDownload(url, overrideOptions: options, progress: progress);

                // PLANO B: Chrome estava aberto e trancou os cookies?
                if (!res.Success && res.ErrorOutput != null && string.Join(" ", res.ErrorOutput).ToLower().Contains("cookie"))
                {
                    TxtStatus.Text = "Chrome bloqueou os cookies. Tentando modo anônimo...";
                    
                    var fallbackOptions = new OptionSet(); 
                    res = await _ytdl.RunVideoDownload(url, overrideOptions: fallbackOptions, progress: progress);
                }

                // Avalia o resultado final
                if (res.Success)
                {
                    TxtStatus.Text = $"Concluído! Salvo em: {Utils.GetDownloadsFolder()}";
                    MessageBox.Show("Download concluído com sucesso!", "ReelApp", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    TxtStatus.Text = "Erro no download.";
                    // Corrigido o aviso de nulo (CS8604) usando "?? Array.Empty<string>()"
                    string erros = string.Join("\n", res.ErrorOutput ?? Array.Empty<string>());
                    MessageBox.Show($"O download falhou.\n{erros}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                TxtStatus.Text = "Erro crítico.";
                MessageBox.Show($"Erro: {ex.Message}", "Erro Crítico", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                BtnBaixar.IsEnabled = true;
                BtnBaixar.Content = "Baixar";
            }
        }

        // Controles Customizados da Janela
        private void BtnMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        
        private void BtnMaximize_Click(object sender, RoutedEventArgs e) => this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        
        private void BtnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}