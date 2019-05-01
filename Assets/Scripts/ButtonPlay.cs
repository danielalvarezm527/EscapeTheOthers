using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPlay : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucciones1;
    public TextMeshProUGUI textoInstrucciones2;
    public TextMeshProUGUI textoInstrucciones3;
    public GameObject A_instrucciones;
    public GameObject C_instrucciones;

    public void CambiarScena(bool cambiar)
    {
        if (cambiar)
            SceneManager.LoadScene(1);
    }

    public void AbrirInstrucciones(bool aInstrucciones)
    {
        if (aInstrucciones)
        {
            textoInstrucciones1.text = "Tapea en el mapa para moverte";
            textoInstrucciones2.text = " Boton B Para atacar al enemigo mas cercano";
            textoInstrucciones3.text = " No te dejes atrapar";
            A_instrucciones.SetActive(false);
            C_instrucciones.SetActive(true);
        }
    }

    public void CerrarInstrucciones(bool cInstrucciones)
    {
        if (cInstrucciones)
        {
            textoInstrucciones1.text = "";
            textoInstrucciones2.text = "";
            textoInstrucciones3.text = "";
            C_instrucciones.SetActive(false);
            A_instrucciones.SetActive(true);
        }
    }
}
