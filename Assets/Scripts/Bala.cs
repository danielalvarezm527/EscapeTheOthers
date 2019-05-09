using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public CanvasScript targetEnemy;

    public GameObject canvas;
    public GameObject enemigo;
    public GameObject target;

    public ParticleSystem particulaMuerte;

    public AudioSource sonidoParticula;

    public Rigidbody esferaRB;

    public bool miro = false;

    public float distancia;

    public Renderer colorBala;

    // Start is called before the first frame update
    void Start()
    {
        sonidoParticula = FindObjectOfType<AudioSource>();
        particulaMuerte = FindObjectOfType<ParticleSystem>();
        esferaRB = this.gameObject.AddComponent<Rigidbody>();
        esferaRB.useGravity = false;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        targetEnemy = canvas.GetComponent<CanvasScript>();
        colorBala = gameObject.GetComponent<Renderer>();
        colorBala.material.color = Color.magenta;
    }

    

    // Update is called once per frame
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
            particulaMuerte.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 4, other.transform.position.z);
            sonidoParticula.Play();
            particulaMuerte.Play();
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
