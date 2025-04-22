namespace Lock_Project
{
    public class BankAccount(decimal initialBalance)
    {
        private decimal balance = initialBalance;
        private readonly object lockObject = new();

        // Метод для зняття грошей з рахунку
        public void Withdraw(decimal amount)
        {
            lock (lockObject) // Забезпечуємо, щоб лише один потік міг виконувати цей код одночасно
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Withdrawing {amount}...");
                    balance -= amount;
                    Console.WriteLine($"{amount} was withdrawn. Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"Insufficient funds for withdrawal {amount}. Balance: {balance}");
                }
            }
        }

        // Метод для перевірки балансу
        public decimal GetBalance()
        {
            lock (lockObject)
            {
                return balance;
            }
        }
    }
}
