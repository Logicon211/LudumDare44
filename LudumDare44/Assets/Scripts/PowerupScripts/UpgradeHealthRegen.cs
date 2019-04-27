﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealthRegen : PowerUp
{

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 30f;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeHealthRegenUp();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}
