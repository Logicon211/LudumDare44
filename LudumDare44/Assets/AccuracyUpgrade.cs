using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyUpgrade : PowerUp
{

    private CraigController cc;

    public override void PowerUpEffect()
    {
        cc.upgradeAccuracy();
        //play some unique sound effect?
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cc = (GameObject.FindGameObjectWithTag("Player")).GetComponent<CraigController>();
    }


}