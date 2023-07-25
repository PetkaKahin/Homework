using System;
using UnityEngine;

namespace Assets.Visitor
{
    [CreateAssetMenu(fileName = "EnemyVisitorFactory", menuName = "Factory/EnemyVisitorFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Human _humanPrefab;
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private Robot _robotPrefab;

        public Enemy Get(EnemyType type, Transform parent)
        {
            switch (type)
            {
                case EnemyType.Elf:
                    return Instantiate(_elfPrefab, parent);

                case EnemyType.Human:
                    return Instantiate(_humanPrefab, parent);

                case EnemyType.Ork:
                    return Instantiate(_orkPrefab, parent);

                case EnemyType.Robot:
                    return Instantiate(_robotPrefab, parent);

                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}
