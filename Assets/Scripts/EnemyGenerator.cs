using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    GameObject spawn1;
    GameObject spawn2;
    GameObject spawn3;
    GameObject spawn4;
    GameObject enemy;
    GameObject enemigo;

    public float tiempo;

    int numSpawn = 0;

    void Start()
    {
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1");
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2");
        spawn3 = GameObject.FindGameObjectWithTag("Spawn3");
        spawn4 = GameObject.FindGameObjectWithTag("Spawn4");

        Generar();

    }

    public void Update()
    {
        tiempo += Time.fixedDeltaTime;

        if (tiempo > 90)
        {
            Generar();
            tiempo = 0;
        }
    }

    public void Generar()
    {
        for (int i = 0; i <= Random.Range(10, 20); i++)
        {
            enemy = GameObject.FindGameObjectWithTag("Cuerpo");

            if (numSpawn == 0)
            {
                enemigo = Instantiate(enemy, spawn1.transform.position, Quaternion.identity);
                enemigo.AddComponent<ControllerEnemy>();
                enemigo.name = "Enemigo";
                enemigo.tag = "Enemy";
                numSpawn += 1;
            }
            else if (numSpawn == 1)
            {
                enemigo = Instantiate(enemy, spawn2.transform.position, Quaternion.identity);
                enemigo.AddComponent<ControllerEnemy>();
                enemigo.name = "Enemigo";
                enemigo.tag = "Enemy";
                numSpawn += 1;
            }
            else if (numSpawn == 2)
            {
                enemigo = Instantiate(enemy, spawn3.transform.position, Quaternion.identity);
                enemigo.AddComponent<ControllerEnemy>();
                enemigo.name = "Enemigo";
                enemigo.tag = "Enemy";
                numSpawn += 1;
            }
            else if (numSpawn == 3)
            {
                enemigo = Instantiate(enemy, spawn4.transform.position, Quaternion.identity);
                enemigo.AddComponent<ControllerEnemy>();
                enemigo.name = "Enemigo";
                enemigo.tag = "Enemy";
                numSpawn += 1;
            }
            else if (numSpawn == 4)
                numSpawn = 0;
        }
    }
}
