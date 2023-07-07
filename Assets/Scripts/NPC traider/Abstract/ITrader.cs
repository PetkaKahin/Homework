namespace NPC_traider
{
    public interface ITrader
    {
        const int MinReputation = -10;
        const int MaxReputation = 10;

        void Trade();
    }
}
