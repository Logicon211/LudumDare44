using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : PowerUp
{

    private CraigController cc;
    private float healthCost = 0.35f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeDamage();        
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
