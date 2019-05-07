using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI Ttiempo;
    public TextMeshProUGUI TNumEnemigos;
    public TextMeshProUGUI TPuntaje;
    public TextMeshProUGUI TMunicion;
    public TextMeshProUGUI TSinMunicion;

    public GameObject[] enemigos;
    public GameObject target;
    public GameObject player;
    public GameObject nada;
    public GameObject elItem;

    public int municion = 10;
    public int tiempoInicial;
    public float escalaDeTiempo = 1;
    public float tiempoFrameTimeScale = 0f;
    public float escalaDelTiempoInicial;
    public float distancia;
    public float tiempo;

    public static float tiempoMostrarSegundos = 0f;
    public static int puntaje = 0;
    public static string tiempoFinal;
    public string sinMunicion;


    public EnemyGenerator generarMas;
    public ControllerEnemy controladorEnemigo;

    void Start()
    {
        escalaDelTiempoInicial = escalaDeTiempo;
        tiempoMostrarSegundos = tiempoInicial;
        ActualizarReloj(tiempoInicial);
        target = GameObject.FindGameObjectWithTag("Nada");
        StartCoroutine(buscaEnemigos());
        puntaje = 0;
    }

    IEnumerator buscaEnemigos()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        nada = GameObject.FindGameObjectWithTag("Nada");


        foreach (GameObject item in enemigos)
        {
            controladorEnemigo = item.GetComponent<ControllerEnemy>();

            if (controladorEnemigo != null)
            {
                distancia = Mathf.Sqrt(Mathf.Pow((item.transform.position.x - player.transform.position.x), 2) + Mathf.Pow((item.transform.position.y - player.transform.position.y), 2) + Mathf.Pow((item.transform.position.z - player.transform.position.z), 2));

                if (distancia < 10)
                {
                    target = item;

                }

            }

        }

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(buscaEnemigos());
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if(municion != 0)
            sinMunicion = " ";

        if (tiempo > 1.5f)
        {
            TSinMunicion.color = Color.red;
            if (tiempo > 3)
            {
                TSinMunicion.color = Color.white;
                tiempo = 0;
            }
        }

        TSinMunicion.text = sinMunicion;
        TMunicion.text = municion.ToString() + " Energias";

        enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        TNumEnemigos.text = enemigos.Length.ToString() + " Enemigos";

        tiempoFrameTimeScale = Time.deltaTime * escalaDeTiempo;

        tiempoMostrarSegundos += tiempoFrameTimeScale;

        ActualizarReloj(tiempoMostrarSegundos);

        TPuntaje.text = puntaje.ToString() + " Puntos";

        if (enemigos.Length == 0)
        {
            if (generarMas.numVecesGenerar > 2)
            {
                generarMas.minimo += 5;
                generarMas.maximo += 5;
                generarMas.numVecesGenerar = 0;
                Debug.Log("Se generaron mas");
            }

            generarMas.Generar();

        }
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
