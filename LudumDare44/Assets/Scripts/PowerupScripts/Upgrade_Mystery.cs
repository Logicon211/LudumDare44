using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Mystery : PowerUp
{

    //private CraigController cc;

    public override float GetHealthLossAmount()
    {
        return 80f;
    }

    public override void PowerUpEffect()
    {
        //Spawn random powerups

        //cc.upgradeMaxHealth();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
      //  cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }
}