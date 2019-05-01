using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesCanvasFin : MonoBehaviour
{
    public void Reiniciar(bool reiniciar)
    {
        if (reiniciar)
            SceneManager.LoadScene(0);
    }
}
