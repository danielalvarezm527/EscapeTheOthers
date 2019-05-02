using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarCajaMunicion : MonoBehaviour
{
    public float tiempo;
    public int cajaWidth = 40;
    public int cajaHeight = 40;
    public int numCajas = 40;

    public GameObject caja;
    public GameObject[] cajas;

    public Light cajaLight;

    public CanvasScript cantidadMuni;

    private void Start()
    {
        cajaLight = caja.GetComponent<Light>();
        cajaLight.intensity = 200;
        caja.name = "Enegia";
        CrearCaja();
    }

    void Update()
    {
        cajas = GameObject.FindGameObjectsWithTag("Caja");

        tiempo += Time.fixedDeltaTime;

        if (tiempo > 100 || cantidadMuni.municion == 0)
        {
            if (cajas.Length < 2)
            {
                CrearCaja();
                tiempo = 0;
            }
        }
    }

    public void CrearCaja()
    {
        Vector3 pos = new Vector3(Random.Range(12, -31), 1.5f, Random.Range(12, -31));
        Instantiate(caja, pos, Quaternion.identity, transform);
        caja.tag = "Caja";
    }
}
