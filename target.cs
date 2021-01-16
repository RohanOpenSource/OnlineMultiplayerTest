using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health=50f;
    public ParticleSystem deathfx;
    public void TakeDamage(float amount)
    
    {
        health -= amount;
        if (health <= 0)
        {
            ParticleSystem fx=Instantiate(deathfx, gameObject.transform.position, Quaternion.identity);
            fx.Play();
            Destroy(gameObject);
        }
    }
    


}
