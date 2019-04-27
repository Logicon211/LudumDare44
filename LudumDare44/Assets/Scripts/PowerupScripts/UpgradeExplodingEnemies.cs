﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeExplodingEnemies : PowerUp
{

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 60f;
    }

    public override void PowerUpEffect()
    {
        cc.UpgradeExplodingEnemies();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}