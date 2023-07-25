namespace Task_6___Decorator
{
    public interface IDamagable : IHealth
    {
        void TakeDamage(int damage);
        void Heal(int value);
    }
}
