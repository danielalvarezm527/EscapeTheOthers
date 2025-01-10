using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ControllerEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private CapsuleCollider colliderEnemy;
    private GameObject player;
    private ThirdPersonCharacter character;

    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        colliderEnemy = this.gameObject.GetComponent<CapsuleCollider>();
        colliderEnemy.isTrigger = true;
        agent.updateRotation = false;
        agent.speed = Random.Range(0.7f, 1);
        agent.stoppingDistance = 0.01f;

        character = GetComponent<ThirdPersonCharacter>();
        if (character == null)
        {
            Debug.LogError("ThirdPersonCharacter component not found on " + gameObject.name);
        }

        Invoke("buscar", 0.1f);
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                return; // Si no se encuentra el jugador, salir del método Update
            }
        }

        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }

    void buscar()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
