namespace Decorator_Project
{
    // Декоратор для молока
    public class Milk(Beverage beverage) : BeverageDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Milk";

        public override decimal Cost() => beverage.Cost() + 0.50m;
    }
}