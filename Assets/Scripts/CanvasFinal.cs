using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasFinal : MonoBehaviour
{
    public string tiempo;

    public float tiempoSegundos;
    public float puntos;
    public float puntajeFinal;

    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoPuntuacionFinal;

    public GameObject panelInicio;
    public GameObject panelFinal;

    void Start()
    {
        if (PlayerController.perdio == true)
        {
            panelInicio.SetActive(false);
            panelFinal.SetActive(true);

            tiempo = CanvasScript.tiempoFinal;
            tiempoSegundos = CanvasScript.tiempoMostrarSegundos;
            puntos = CanvasScript.puntaje;

            puntajeFinal = tiempoSegundos + puntos;

            textoTiempo.text = tiempo + " Segundos";
            textoPuntos.text = puntos.ToString() + " Puntos";
            textoPuntuacionFinal.text = puntajeFinal.ToString("000") + " Puntos totales";
        }
        else
        {
            panelFinal.SetActive(false);
            panelInicio.SetActive(true);
        }
    }

}
