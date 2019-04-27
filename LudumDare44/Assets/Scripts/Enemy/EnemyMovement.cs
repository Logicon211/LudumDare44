using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public IEnemy controller;
    public float maxDistance = 20f;
    public float shootDistance = 40f;
    public float speed = 10f;
    public float shootSpeed = 20f;

    private GameObject player;
    private Transform playerTransform;
    private bool move = false;
    private bool shoot = false;
    private Vector3 moveDir = Vector3.zero;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
    // Update is called once per frame
    void Update () {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > maxDistance) {
            move = true;
        }
        if (dist < shootDistance) {
            shoot = true;
        }

    }

    void FixedUpdate() {
        Vector3 normal = (player.transform.position - transform.position).normalized;
        if (move) {
            moveDir = normal;	
        }
        if (shoot) {
            controller.Attack(normal.x * shootSpeed * Time.fixedDeltaTime, normal.y * shootSpeed * Time.fixedDeltaTime);
            shoot = false;
        }
        controller.Move(moveDir.x * speed * Time.fixedDeltaTime, moveDir.y * speed * Time.fixedDeltaTime);
        controller.Rotate(normal);
        moveDir = Vector3.zero;
        move = false;
    }
}
