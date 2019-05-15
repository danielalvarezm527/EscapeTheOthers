using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public CanvasScript targetEnemy;

    public GameObject canvas;
    public GameObject enemigo;
    public GameObject target;

    public Rigidbody esferaRB;

    public bool miro = false;

    public float distancia;

    public Renderer colorBala;

    void Start()
    {
        esferaRB = this.gameObject.AddComponent<Rigidbody>();
        esferaRB.useGravity = false;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        targetEnemy = canvas.GetComponent<CanvasScript>();
        colorBala = gameObject.GetComponent<Renderer>();
        colorBala.material.color = Color.magenta;
    }

    void Update()
    {

        if (!miro)
        {
            this.gameObject.transform.LookAt(targetEnemy.target.transform);
            miro = true;
        }

        esferaRB.AddForce(transform.forward * 50);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CanvasScript.puntaje += 10;
            Destroy( this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Muro")
        {
            Destroy(this.gameObject);
        }

    }
}
