using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVolume : PowerUp
{

    private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 10f;
    }

    public override void PowerUpEffect()
    {
        cc.upgradeBulletVolume();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}
