using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeKnockback : PowerUp
{

    private CraigController cc;
    private float healthCost = 0.5f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeKnockback();
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
