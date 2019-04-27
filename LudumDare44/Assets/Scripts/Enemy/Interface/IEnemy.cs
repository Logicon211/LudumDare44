using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemy
    {
        void Move(float tarX, float tarY);

        void Rotate(Vector3 direction);

        void Attack(float tarX, float tarY);
    }
}
