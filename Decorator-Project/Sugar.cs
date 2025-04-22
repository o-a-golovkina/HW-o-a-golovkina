namespace Decorator_Project
{
    // Декоратор для цукру
    public class Sugar(Beverage beverage) : BeverageDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Sugar";

        public override decimal Cost() => beverage.Cost() + 0.30m;
    }
}