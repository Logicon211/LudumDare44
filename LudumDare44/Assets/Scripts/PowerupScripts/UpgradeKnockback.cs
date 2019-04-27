﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeKnockback : PowerUp
{

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 50f;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeKnockback();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}