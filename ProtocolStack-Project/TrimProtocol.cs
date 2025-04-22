namespace ProtocolStack_Project
{
    // Протокол для видалення зайвих пробілів на початку і в кінці
    public class TrimProtocol : Protocol
    {
        public override string ProcessData(string data)
        {
            string trimmedData = data.Trim();
            Console.WriteLine($"Trimmed data: {trimmedData}");

            if (nextProtocol != null)
            {
                return nextProtocol.ProcessData(trimmedData);
            }

            return trimmedData;
        }
    }
}