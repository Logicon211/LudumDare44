using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeExplodingEnemies : PowerUp
{

    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SetHealthCost(0.6f);
    }
    
    public override void PowerUpEffect()
    {
           //Turn on explosions
        //play some unique sound effect?
    }

}