using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scriptCamera1 : MonoBehaviour
{
    public CinemachineVirtualCamera camera;

    void Update()
    {
        if (camera.m_LookAt == null)
        {
            camera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
            camera.m_LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        }      
    }
}
