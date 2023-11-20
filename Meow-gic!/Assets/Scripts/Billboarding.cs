using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public Camera m_camera;
    public Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tran.transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward, m_camera.transform.rotation * Vector3.up);
    }
}
