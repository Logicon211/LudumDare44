using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeExplodingEnemies : PowerUp
{

    

    public override float GetHealthLossAmount()
    {
        return 0.6f;
    }

    public override void PowerUpEffect()
    {
           //Turn on explosions
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
}