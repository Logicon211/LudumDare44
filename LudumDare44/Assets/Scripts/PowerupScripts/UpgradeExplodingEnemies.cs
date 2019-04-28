using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeExplodingEnemies : PowerUp
{

    private float healthCost = 0.6f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
           //Turn on explosions
        //play some unique sound effect?
    }

    public override void SetHealthCostFree()
    {
        healthCost = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
}