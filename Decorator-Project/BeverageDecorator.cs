namespace Decorator_Project
{
    // Декоратор - базовий клас для добавок
    public abstract class BeverageDecorator(Beverage beverage) : Beverage
    {
        public Beverage beverage = beverage;

        public override string GetDescription() => beverage.GetDescription();
    }
}
