using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
    
    public GameObject projectile;
    public float projectileSpeed;


    private void Start()
    {
        
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) )//&& currentMana >= 300)
        {
            GameObject fireball = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            fireball.transform.position = transform.position + transform.forward * 2;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
        }
        
    }
}
