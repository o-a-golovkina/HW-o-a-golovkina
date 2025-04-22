namespace ProtocolStack_Project
{
    // Протокол для додавання префікса до рядка
    public class PrefixProtocol(string prefix) : Protocol
    {
        private readonly string _prefix = prefix;

        public override string ProcessData(string data)
        {
            string prefixedData = _prefix + data;
            Console.WriteLine($"Prefixed data: {prefixedData}");

            if (nextProtocol != null)
            {
                return nextProtocol.ProcessData(prefixedData);
            }

            return prefixedData;
        }
    }
}