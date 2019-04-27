using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemy
    {
        // Move the enemy
        void Move(float tarX, float tarY);

        // Rotate the enemy
        void Rotate(Vector3 direction);

        // Attack shit towards target
        void Attack(float tarX, float tarY);
    }
}
