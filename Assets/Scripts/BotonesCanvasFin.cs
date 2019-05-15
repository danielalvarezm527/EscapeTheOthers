using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesCanvasFin : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelFinal;

    public void Reiniciar(bool reiniciar)
    {
        if (reiniciar)
        {
            panelFinal.SetActive(false);
            panelInicio.SetActive(true);
            PlayerController.perdio = false;
        }
            
    }
}
