using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;
    
public class CrudeCriminal : MonoBehaviour, IEnemy, IKillable, IDamageable<float>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Kill()
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
