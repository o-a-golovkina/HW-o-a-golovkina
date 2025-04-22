namespace ProtocolStack_Project
{
    // Протокол для стиснення даних
    public class ProtocolStack(Protocol firstProtocol)
    {
        private readonly Protocol firstProtocol = firstProtocol;

        public void Process(string data)
        {
            firstProtocol.ProcessData(data);
        }
    }
}
