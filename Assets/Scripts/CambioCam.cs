using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCam : MonoBehaviour
{
    public GameObject b_Uno;
    public GameObject b_Dos;
    public GameObject camera1;
    public GameObject camera2;

    public void cambio1(bool cambiar1)
    {
        if (cambiar1)
        {
            b_Uno.SetActive(false);
            b_Dos.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }

    public void cambio2(bool cambiar2)
    {
        if (cambiar2)
        {
            b_Dos.SetActive(false);
            b_Uno.SetActive(true);
            camera2.SetActive(false);
            camera1.SetActive(true);
        }
    }
}
