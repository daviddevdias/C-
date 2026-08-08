using System;
using System.IO;

namespace ReelApp
{
    public static class Utils
    {
        // Encontra a pasta padrão de Downloads do usuário
        public static string GetDownloadsFolder()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string downloadsPath = Path.Combine(userProfile, "Downloads", Config.AppTitle);
            
            if (!Directory.Exists(downloadsPath))
                Directory.CreateDirectory(downloadsPath);
                
            return downloadsPath;
        }

        // Formata os bytes (ex: 1024 -> "1.00 KB")
        public static string FormatBytes(long bytes)
        {
            if (bytes == 0) return "0 MB";
            
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return $"{dblSByte:0.##} {suffix[i]}";
        }

        // Converte segundos para HH:MM:SS
        public static string FormatDuration(TimeSpan? duration)
        {
            if (!duration.HasValue) return "00:00";
            return duration.Value.ToString(duration.Value.Hours > 0 ? @"h\:mm\:ss" : @"m\:ss");
        }
    }
}