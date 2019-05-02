using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    public CanvasScript municion;

    public GameObject canvas;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        municion = canvas.GetComponent<CanvasScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Muro")
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            municion.municion += 10;
            Destroy(this.gameObject);
        }
    }
}
