using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarPiso : MonoBehaviour
{
    public float tiempo;
    public float graduador;
    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        graduador = 0.1f;   
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.fixedDeltaTime;

        if (tiempo > 5)
        {
            x = gameObject.transform.localScale.x;
            z = gameObject.transform.localScale.z;
            x -= graduador;
            z -= graduador;

            this.gameObject.transform.localScale = new Vector3(x, gameObject.transform.localScale.y, z);

            if (x <= 2.1f)
                graduador = 0;
        }
    }
}
