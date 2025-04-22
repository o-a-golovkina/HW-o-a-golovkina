using Decorator_Project;

Beverage beverage1 = new Coffee();
Console.WriteLine(beverage1.GetDescription() + " $" + beverage1.Cost());

// Додаємо молоко до кави
beverage1 = new Milk(beverage1);
Console.WriteLine(beverage1.GetDescription() + " $" + beverage1.Cost());

// Додаємо цукор до кави з молоком
beverage1 = new Sugar(beverage1);
Console.WriteLine(beverage1.GetDescription() + " $" + beverage1.Cost());

Console.WriteLine();

// Замовляємо чай з молоком
Beverage beverage2 = new Tea();
beverage2 = new Milk(beverage2);
Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());
