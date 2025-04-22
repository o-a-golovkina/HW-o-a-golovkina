namespace RAII_Project
{
    public class FileManager : IDisposable
    {
        private FileStream file;
        private bool disposed = false;

        // Конструктор, який ініціалізує ресурс (відкриває файл)
        public FileManager(string filePath)
        {
            try
            {
                file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Console.WriteLine("The file is opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file was not opened: {ex.Message}");
            }
        }

        // Метод для запису в файл (демонстрація використання ресурсу)
        public void WriteToFile(string text)
        {
            if (file != null)
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(text);
                    Console.WriteLine("Text has been written into the file!");
                }
            }
        }

        // Деструктор (або метод Dispose) для автоматичного закриття ресурсу
        ~FileManager()
        {
            Dispose(false);
        }

        // Реалізація IDisposable для коректного звільнення ресурсів
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Закриття файлу та очищення ресурсів
        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    file.Dispose();
                }
                Console.WriteLine("The file was closed and is cleaned.");
                disposed = true;
            }
        }
    }
}
