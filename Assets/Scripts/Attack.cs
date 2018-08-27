using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float damage = 50.0F;
    public float attackDuration = 0.3F;

    [HideInInspector]

    public bool attacking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("h"))
        {
            attacking = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Enemy")
        {
            if (attacking)
            {
                col.SendMessage("receiveDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void EnableDamage()
    {
        if (attacking == true) return;
        attacking = true;
        StartCoroutine("DisableDamage");
    }

    IEnumerator DisableDamage()
    {
        yield return new WaitForSeconds(attackDuration);
        attacking = false;
    }

}
