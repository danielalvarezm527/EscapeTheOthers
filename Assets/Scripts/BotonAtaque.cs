using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAtaque : MonoBehaviour
{
    public ParticleSystem bolaDeFuego;

    public void Atacar(bool ataca)
    {
        if (ataca)
            bolaDeFuego.Play();
    }
}
