using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBulletTime : PowerUp
{

    private float healthCost = 0.7f;

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeBulletTime();
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
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}
