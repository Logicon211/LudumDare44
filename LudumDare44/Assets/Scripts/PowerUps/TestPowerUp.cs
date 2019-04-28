using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPowerUp : PowerUp
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void PowerUpEffect()
    {
     //   throw new System.NotImplementedException();
    }

    public override float GetHealthLossAmount()
    {
        return 0.3f;
    }

    public override void SetHealthCostFree()
    {
        throw new System.NotImplementedException();
    }
}
