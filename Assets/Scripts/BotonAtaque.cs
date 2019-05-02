using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAtaque : MonoBehaviour
{
    public GameObject bala;
    public GameObject player;

    public TrailRenderer trailBala;

    public CanvasScript target;

    public bool disparo = false;

    public void dispara(bool disparar)
    {
        if (disparar)
        {
            if (target.municion != 0)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.transform.LookAt(target.target.transform);

                disparo = true;
                if (disparo)
                {
                    bala = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    bala.GetComponent<Collider>().isTrigger = true;
                    bala.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    bala.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z);
                    bala.AddComponent<TrailRenderer>();
                    trailBala = bala.GetComponent<TrailRenderer>();
                    trailBala.receiveShadows = false;
                    trailBala.time = 0.5f;
                    trailBala.minVertexDistance = 0.5f;
                    trailBala.startWidth = 0.3f;
                    trailBala.endWidth = 0f;
                    trailBala.endColor = Color.red;
                    bala.AddComponent<Bala>();
                    target.municion -= 1;
                    disparar = false;
                }
            }
            else if (target.municion == 0)
            {
                target.sinMunicion = "No tienes mas balas";
            }
        }
    }
}
