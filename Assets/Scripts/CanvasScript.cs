using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI Ttiempo;
    public TextMeshProUGUI TNumEnemigos;

    public GameObject[] enemigos;

    public int tiempoInicial;
    public float escalaDeTiempo = 1;
    public float tiempoFrameTimeScale = 0f;
    public float tiempoMostrarSegundos = 0f;
    public float escalaDelTiempoInicial;

    public static string tiempoFinal;

    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;
        tiempoMostrarSegundos = tiempoInicial;
        ActualizarReloj(tiempoInicial);

    }

    void Update()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        TNumEnemigos.text = enemigos.Length.ToString();

        tiempoFrameTimeScale = Time.deltaTime * escalaDeTiempo;

        tiempoMostrarSegundos += tiempoFrameTimeScale;

        ActualizarReloj(tiempoMostrarSegundos);       
    }

    void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0)
            tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        Ttiempo.text = textoDelReloj;

        tiempoFinal = textoDelReloj;
    }
}
