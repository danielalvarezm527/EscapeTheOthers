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

    // Start is called before the first frame update
    void Start()
    {
        esferaRB = this.gameObject.AddComponent<Rigidbody>();
        esferaRB.useGravity = false;

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        targetEnemy = canvas.GetComponent<CanvasScript>();

    }

    

    // Update is called once per frame
    void Update()
    {

        if (!miro)
        {
            this.gameObject.transform.LookAt(targetEnemy.target.transform);
            miro = true;
        }

        esferaRB.AddForce(transform.forward * 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CanvasScript.puntaje += 10;
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Muro")
        {
            Destroy(this.gameObject);
        }
    }
}
