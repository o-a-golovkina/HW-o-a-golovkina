namespace ProtocolStack_Project
{
    // Базовий клас протоколу
    public abstract class Protocol
    {
        protected Protocol nextProtocol = null!;

        public void SetNextProtocol(Protocol nextProtocol)
        {
            this.nextProtocol = nextProtocol;
        }

        public abstract string ProcessData(string data);
    }
}
