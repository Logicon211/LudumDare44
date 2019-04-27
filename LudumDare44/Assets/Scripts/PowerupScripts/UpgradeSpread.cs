using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpread : PowerUp
{

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 70f;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeSpread();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}