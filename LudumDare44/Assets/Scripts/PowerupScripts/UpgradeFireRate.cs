using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFireRate : PowerUp
{
    private float healthCost = 0.25f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    private CraigController cc;

    public override void PowerUpEffect()
    {
        cc.upgradeFireRate();
        //play some unique sound effect?
    }

    public override void SetHealthCostFree()
    {
        healthCost = 0;
        Debug.Log("HEALTHCOSTSET");
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }


}