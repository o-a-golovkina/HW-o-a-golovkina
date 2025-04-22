using ProtocolStack_Project;

// Створюємо протоколи
Protocol uppercase = new UppercaseProtocol();
Protocol trim = new TrimProtocol();
Protocol prefix = new PrefixProtocol("HAVE ");

// Зв'язуємо їх у стек
uppercase.SetNextProtocol(trim);
trim.SetNextProtocol(prefix);

// Створюємо стек
ProtocolStack protocolStack = new(uppercase);

// Передаємо дані через стек
string data = "   a nice day!   ";
Console.WriteLine("Original Data: " + data);
protocolStack.Process(data);