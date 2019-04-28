using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCraigSpeed : PowerUp
{

    private CraigController cc;
    private float healthCost;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeCraigSpeed();
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
        healthCost = 0.2f;
    }
}