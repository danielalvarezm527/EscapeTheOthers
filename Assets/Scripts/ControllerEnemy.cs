﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ControllerEnemy : MonoBehaviour
{

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public CapsuleCollider colliderEnemy;

    public GameObject player;

    void Start()
    {
        this.gameObject.AddComponent<NavMeshAgent>();
        character = this.gameObject.GetComponent<ThirdPersonCharacter>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        colliderEnemy = this.gameObject.GetComponent<CapsuleCollider>();
        colliderEnemy.isTrigger = true;
        agent.updateRotation = false;
        agent.speed = Random.Range(0.7f, 1);
        agent.stoppingDistance = 0.01f;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}