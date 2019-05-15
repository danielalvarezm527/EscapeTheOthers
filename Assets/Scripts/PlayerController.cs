using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera camara;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public Vector3 vec;

    public GameObject canvas;

    public int contadorTouch = 0;

    public static bool perdio = false; 

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        this.gameObject.tag = "Player";
        camara = FindObjectOfType<Camera>();
        agent.updateRotation = false;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Muro")
                {
                    Touch touch = Input.GetTouch(0);
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        vec = hit.point;
                        agent.SetDestination(vec);
                    }

                }
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            perdio = true;
            SceneManager.LoadScene(0);
        }
    }
}