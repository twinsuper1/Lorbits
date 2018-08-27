using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public const float maxHP = 100.0F;
    public float currentHP = 100.0F;
    public GameObject Enemy;

    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        checkStatus();
    }

    public void checkStatus()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            death();
        }
        else if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public void receiveDamage(float damage)
    {

        currentHP -= damage;
        Debug.Log(Enemy + " took " + damage + " damage!");
    }

    public void death()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Spell")
        {
            currentHP -= 20;
            Destroy(col.collider);
        }
    }
}