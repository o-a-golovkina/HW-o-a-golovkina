using Lock_Project;

// Створюємо банківський рахунок з початковим балансом
BankAccount account = new(1000);

// Створюємо кілька потоків, які намагаються зняти гроші
Thread thread1 = new(() => WithdrawMoney(account, 500));
Thread thread2 = new(() => WithdrawMoney(account, 700));
Thread thread3 = new(() => WithdrawMoney(account, 300));

// Запускаємо потоки
thread1.Start();
thread2.Start();
thread3.Start();

// Чекаємо, поки всі потоки завершаться
thread1.Join();
thread2.Join();
thread3.Join();

// Метод для зняття грошей в окремому потоці
static void WithdrawMoney(BankAccount account, decimal amount)
{
    account.Withdraw(amount);
}