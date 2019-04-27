using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool active = false;

    public int[] ninjas;
    public int[] crudeCriminals;
    public int[] oilOrks;
    public int numberOfWaves;
    // Start is called before the first frame update

    private int currentWaveNumber = -1;

    public int currentAliveEnemyCount = 0;

    public Transform[] spawnPoints;
    public GameObject door;

    private GameObject player;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
    // Update is called once per frame
    void Update()
    {
        if(active) {
            if(currentAliveEnemyCount <=0) {
                currentWaveNumber++;

                if(currentAliveEnemyCount >= numberOfWaves - 1) {
                    //Open door to next room
                }

                //Spawn some guys in
            }
        }
    }

    public Vector2 PickSpawnPointNotOnPlayer() {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		Transform closestPoint = null;
		foreach(Transform point in spawnPoints) {
			if(closestPoint == null || Vector2.Distance(point.position, player.transform.position) < Vector2.Distance(closestPoint.position, player.transform.position)) {
				closestPoint = point;
			}
		}

		Vector2 chosenPosition;
		bool spawnPointChosen = false;
		while (!spawnPointChosen) {
			chosenPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

			if(!chosenPosition.Equals(closestPoint.position)) {
				return chosenPosition;
			}
		}

		return new Vector2();
	}

    public void DecrementAliveEnemyCount() {
        currentAliveEnemyCount--;
    }

    public void DeactivateRoom() {
        //Close door behind player and show the roof
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" ) {
            DeactivateRoom();
        }
    }
}
