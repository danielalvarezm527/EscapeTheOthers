using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasFinal : MonoBehaviour
{
    public string tiempo;

    public TextMeshProUGUI textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = CanvasScript.tiempoFinal;
        textoTiempo.text = tiempo + " Segundos";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
