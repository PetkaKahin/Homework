namespace Weapon
{
    public interface IClickMouseHandler
    {
        const int LeftBatton = 0;
        const int RightBatton = 0;

        bool MosueClick(int mouseButton);
    }
}
