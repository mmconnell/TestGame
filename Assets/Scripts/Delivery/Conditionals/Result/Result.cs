namespace Delivery
{
    public abstract class Result : Conditional
    {
        public override bool IsCondition()
        {
            return false;
        }
    }
}