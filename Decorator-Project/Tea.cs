namespace Decorator_Project
{
    public class Tea : Beverage
    {
        public Tea()
        {
            Description = "Tea";
        }

        public override decimal Cost() => 0.75m;
    }
}
