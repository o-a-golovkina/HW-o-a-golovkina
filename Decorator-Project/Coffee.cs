namespace Decorator_Project
{
    public class Coffee : Beverage
    {
        public Coffee()
        {
            Description = "Coffee";
        }

        public override decimal Cost() => 1.99m;
    }
}
