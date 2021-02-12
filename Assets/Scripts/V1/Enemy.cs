using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [Tooltip("GameObject with particles ")][SerializeField] 
    private GameObject deathFX;
    [SerializeField]
    private Transform parent;
    [SerializeField] 
    private int scorePerHit = 14;
    [SerializeField]
    private int hits = 3;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hits <= 0)
        {
            DestoryEnemy();
        }
    }

    private void ProcessHits()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void DestoryEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
