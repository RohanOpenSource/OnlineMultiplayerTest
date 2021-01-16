using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public LineRenderer lr;
    public LayerMask shootable;
    public Transform guntip, camera;
    public float maxDistance=100f;
    public ParticleSystem shot;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        void shoot()
        {
            shot.Play();
            RaycastHit hit;
            if(Physics.Raycast(camera.position, camera.forward, out hit,maxDistance))
            {
                target t=hit.transform.GetComponent<target>();
                if (t != null)
                {
                    t.TakeDamage(10f);
                }
            }

        }
    }

}
