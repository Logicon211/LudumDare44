using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFireRate : PowerUp
{

    public override float GetHealthLossAmount()
    {
        return 25f;
    }

    private CraigController cc;

    public override void PowerUpEffect()
    {
        cc.upgradeFireRate();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}