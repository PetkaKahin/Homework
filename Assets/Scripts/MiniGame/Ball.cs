using System;
using UnityEngine;

namespace MiniGame
{
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public BallType Type { get; private set; }

        public static event Action<Ball> EventDestroyedActionReturnBall; // не знаю как лучше сделать, наверное бахнуть это через кликер, хотя это и не его ответственноесть, наверное)
        public static event Action EventDestroyedAction; // просто очень много где используется, и если не сделать статику, то придется пихать множество ссылок на эвенты во много скриптов
        // хотя можно сделать единую точку входа, там указать ссылки на все скрипты и затолкать в них сущность с эвентами, но опять же таки, это будет не так удобно в дальнейшем использовании
        // тут в любом случае придется в каждый скрипт добовлять ссылки на эвенты

        public Ball(BallType type)
        {
            Type = type;
        }

        public void DestroyedBall()
        {
            EventDestroyedActionReturnBall?.Invoke(this);
            EventDestroyedAction?.Invoke();

            Destroy(gameObject);
        }
    }

    public enum BallType
    {
        Red,
        Green,
        White,
    }
}
