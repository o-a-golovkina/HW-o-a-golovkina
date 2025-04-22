namespace RAII_Project
{
    class Program
    {
        static void Main()
        {
            string filePath = "test.txt";

            // Використовуємо конструкцію using для автоматичного звільнення ресурсу
            using (FileManager fileManager = new FileManager(filePath))
            {
                fileManager.WriteToFile("Hello world!\n" + DateTime.Now);
            }

            // У цей момент, коли блок using завершується, викликається Dispose і файл закривається
            Console.WriteLine("Resourses is cleaned automatically");
        }
    }
}
