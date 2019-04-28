using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHeatCost : PowerUp
{

    private CraigController cc;
    private float healthCost = 0.3f;

    public override float GetHealthLossAmount()
    {
        return 0.3f;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeHeatCost();
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