using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonPlay : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucciones;
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
            textoInstrucciones.text = "Tapea en el mapa para moverte para moverte" + " Boton B Para atacar " + " No te dejes atrapar";
            A_instrucciones.SetActive(false);
            C_instrucciones.SetActive(true);
        }
    }

    public void CerrarInstrucciones(bool cInstrucciones)
    {
        if (cInstrucciones)
        {
            textoInstrucciones.text = "";
            C_instrucciones.SetActive(false);
            A_instrucciones.SetActive(true);
        }
    }
}
