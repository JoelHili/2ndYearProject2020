using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 1;
    public Rigidbody rb;
    public Transform target;

    public static float enemyDifficulty = 0.5f;

    private void Start()
    {
        rb.mass = enemyDifficulty;
    }

    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public static void increaseDifficulty()
    {
        enemyDifficulty += 0.1f;
    }

    public static void decreaseDifficulty()
    {
        enemyDifficulty -= 0.1f;
    }
}
