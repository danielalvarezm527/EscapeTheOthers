using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera camara;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public GameObject canvas;

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
                    agent.SetDestination(hit.point);
                }
                        
            }
        }


        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);


    }

    /*void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Hit UI, Ignore Touch");
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = camara.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        agent.SetDestination(hit.point);
                    }
                }

                if (agent.remainingDistance > agent.stoppingDistance)
                    character.Move(agent.desiredVelocity, false, false);
                else
                    character.Move(Vector3.zero, false, false);

            }
        }
    }*/

    /* Update()
    {
        RaycastHit hit;

        if (Input.touchCount >= 0)
        {
            foreach (Touch t in Input.touches)
            {
                if (EventSystem.current.IsPointerOverGameObject(t.fingerId))
                {
                    // hit UI , so ignore
                    Debug.Log("HIT UI AN IGNORED - YEAH RIGHT!");
                }
                else
                {
                    Ray ray = camara.ScreenPointToRay(t.position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        agent.SetDestination(t.position);

                        if (t.phase == TouchPhase.Began)
                        {
                            Debug.Log("FINGER BEGAN = " + t.fingerId);
                            Debug.Log("BEHIND BUTTON TRUE OR FALSE? = " + EventSystem.current.IsPointerOverGameObject(t.fingerId));

                            

                        }
                    }
                }
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);
    }*/
}