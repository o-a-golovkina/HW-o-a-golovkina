namespace Decorator_Project
{
    public abstract class Beverage
    {
        public string Description { get; set; } = "Unknown Beverage";

        public virtual string GetDescription() => Description;

        public abstract decimal Cost();
    }
}
