﻿using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    public float maxDistance = 20f;
    public float attackDistance = 40f;
    public float speed = 10f;
    public float attackSpeed = 20f;
    public float attackCooldown = 5f;

    private GameObject player;
    private Transform playerTransform;
    private bool move = false;
    private bool attack = false;
    private Vector3 moveDir = Vector3.zero;
    private IEnemy controller;
    private float currentAttackCooldown;

    // Use this for initialization
    private void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        this.controller = this.gameObject.GetComponent<IEnemy>();
        currentAttackCooldown = attackCooldown;
    }
	
    // Update is called once per frame
    private void Update () {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        currentAttackCooldown -= Time.deltaTime;
        if (dist > maxDistance) {
            move = true;
        }
        if (dist < attackDistance && currentAttackCooldown <= 0f)
        {
            attack = true;
        }

    }

    private void FixedUpdate() {
        Vector3 normal = (player.transform.position - transform.position).normalized;
        if (move) {
            moveDir = normal;	
        }
        if (attack) {
            controller.Attack(normal.x * attackSpeed * Time.fixedDeltaTime, normal.y * attackSpeed * Time.fixedDeltaTime);
            ResetAttack();
        }
        controller.Move(moveDir.x * speed * Time.fixedDeltaTime, moveDir.y * speed * Time.fixedDeltaTime);
        controller.Rotate(normal);
        moveDir = Vector3.zero;
        move = false;
    }

    private void ResetAttack()
    {
        attack = false;
        currentAttackCooldown = attackCooldown;
    }

    public float GetAttackRange()
    {
        return attackDistance;
    }
}