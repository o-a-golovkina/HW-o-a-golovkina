namespace ProtocolStack_Project
{
    // Протокол для перетворення всіх літер в рядку на великі
    public class UppercaseProtocol : Protocol
    {
        public override string ProcessData(string data)
        {
            string upperCaseData = data.ToUpper();
            Console.WriteLine($"Uppercased data: {upperCaseData}");

            if (nextProtocol != null)
            {
                return nextProtocol.ProcessData(upperCaseData);
            }

            return upperCaseData;
        }
    }
}