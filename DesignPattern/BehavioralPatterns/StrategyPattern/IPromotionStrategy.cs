namespace DesignPattern.BehavioralPatterns.StrategyPattern
{
    public interface IPromotionStrategy
    {
        double DoDiscount(double price);
    }
}