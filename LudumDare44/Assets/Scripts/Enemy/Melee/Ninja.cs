using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;

public class Ninja: MonoBehaviour, IDamageable<float>, IKillable, IEnemy
{
    private void Start()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
    
    public void Kill()
    {
        throw new System.NotImplementedException();
    }

    public void Move(float tarX, float tarY)
    {
        throw new System.NotImplementedException();
    }

    public void Rotate(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Attack(float tarX, float tarY)
    {
        throw new System.NotImplementedException();
    }
}
