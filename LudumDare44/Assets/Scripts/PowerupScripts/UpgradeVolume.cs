using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVolume : PowerUp
{

    private CraigController cc;
    private float healthCost = 0.1f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeBulletVolume();
        //play some unique sound effect?
    }

    public override void SetHealthCostFree()
    {
        healthCost=0;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}
