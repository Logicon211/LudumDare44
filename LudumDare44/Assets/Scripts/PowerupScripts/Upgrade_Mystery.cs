using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Mystery : PowerUp
{

    public GameObject SpawnerPrefab;
    private Powerup_Spawner P_Spawner;
    private float healthCost = 0.7f;

    public override float GetHealthLossAmount()
    {
        return healthCost;
    }

    public override void PowerUpEffect()
    {
        int Numtospawn = (int)Random.Range(1, 4);
        //Spawn random powerups

        if (Numtospawn == 1)
        {
            GameObject instantiatedPowerupSpawner = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(0, 2, 0)), Quaternion.identity);
            GameObject Powerup1 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner);
            Debug.Log(Powerup1);
            Powerup1.GetComponent<PowerUp>().SetHealthCostFree();
        }
        if (Numtospawn == 2)
        {
            GameObject instantiatedPowerupSpawner = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(3, 2, 0)), Quaternion.identity);
            GameObject instantiatedPowerupSpawner2 = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(-3, 2, 0)), Quaternion.identity);
            GameObject Powerup1 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner);
            GameObject Powerup2 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner2);
            Debug.Log(Powerup1);
            Powerup1.GetComponent<PowerUp>().SetHealthCostFree();
            Powerup2.GetComponent<PowerUp>().SetHealthCostFree();

        }
        if(Numtospawn == 3)
        {
            GameObject instantiatedPowerupSpawner = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(3, 2, 0)), Quaternion.identity);
            GameObject instantiatedPowerupSpawner2 = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(0, 2, 0)), Quaternion.identity);
            GameObject instantiatedPowerupSpawner3 = Instantiate(SpawnerPrefab, (this.transform.position + new Vector3(-3, 2, 0)), Quaternion.identity);
            GameObject Powerup1 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner);
            GameObject Powerup2 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner2);
            GameObject Powerup3 = P_Spawner.SpawnPowerUp(instantiatedPowerupSpawner3);
            Debug.Log(Powerup1);
            Powerup1.GetComponent<PowerUp>().SetHealthCostFree();
            Powerup2.GetComponent<PowerUp>().SetHealthCostFree();
            Powerup3.GetComponent<PowerUp>().SetHealthCostFree();
        }



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
        if (P_Spawner == null)
        {
            P_Spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<Powerup_Spawner>();
        }

    }
}