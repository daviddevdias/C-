# Estudos de C# e aplicativo Reel

Exercícios de programação em C# e um aplicativo desktop para download de vídeos.

## 📌 Funcionalidades

- Exercícios de console em `Aprendizagem iniciante`.
- Interface WPF em `Download Videos/ReelApp`.
- Integração com YoutubeDLSharp, yt-dlp e FFmpeg.

## Tecnologias

C#, .NET 10 e WPF. O aplicativo Reel requer Windows.

## 🚀 Como executar

```bash
git clone https://github.com/daviddevdias/C-.git
cd C-
dotnet run --project "Aprendizagem iniciante/Aulas 1/Aula01/Aprendizagem iniciante.csproj"
```

Para executar o Reel:

```bash
dotnet restore "Download Videos/ReelApp/ReelApp.csproj"
dotnet run --project "Download Videos/ReelApp/ReelApp.csproj"
```

O aplicativo prepara yt-dlp e FFmpeg na inicialização e salva os arquivos em Downloads/Reel. As opções visuais de formato, qualidade e playlist estão em desenvolvimento. Use links de conteúdo que você tem permissão para baixar.
