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
    public GameManager gameManager;

    public Camera camara;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public Vector3 vec;

    public GameObject canvas;

    public int contadorTouch = 0;

    public static bool perdio = false; 

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        this.gameObject.tag = "Player";
        camara = FindObjectOfType<Camera>();
        agent.updateRotation = false;

    }

    void Update()
    {
        #if UNITY_EDITOR
        // Movimiento con el mouse en el inspector
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return; // Si el puntero está sobre un objeto de la UI, no procesar el movimiento
            }

            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Muro")
                {
                    vec = hit.point;
                    agent.SetDestination(vec);
                }
            }
        }
        #else
        // Movimiento con toques en Android
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return; // Si el toque está sobre un objeto de la UI, no procesar el movimiento
                }

                Ray ray = camara.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Muro")
                    {
                        vec = hit.point;
                        agent.SetDestination(vec);
                    }
                }
            }
        }
        #endif

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
            gameManager.DisplayAds();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
            // SceneManager.LoadScene(0);
        }
    }
}