namespace GUI
{
    public static class Log
    {
        private readonly static string Folder =
            Path.GetDirectoryName(typeof(Log).Assembly.Location) + "\\Logs";
        private static string FilePath =
            $"{Folder}\\{DateTime.Now.ToString("dd-MM-yyyyTHH-mm-ssZ")}.log";
        private static object locker = new();

        static Log()
        {
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
        }

        public static void Info(object info)
        {
            lock (locker)
            {
                try
                {
                    File.AppendAllText(
                        FilePath,
                        $"[{DateTime.Now.ToString("dd-MM-yyyyTHH:mm:ss.fff")}]\t{info}{Environment.NewLine}"
                    );
                }
                catch (Exception ex)
                {
                    Dialog(
                        $"Cannot append log file.{Environment.NewLine}Log message: {info}.{Environment.NewLine}Exception: {ex}"
                    );
                }
            }
        }

        public static void LogErrors(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Info(ex);
            }
        }

        public static object? LogErrors(Func<object> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Info(ex);
            }
            return null;
        }

        public static void Dialog(string info)
        {
            MessageBox.Show(info);
        }
    }
}
