using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    //https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health
    public float maxHealth = 1000;
    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;

    bool isDead;
    bool damaged;

	// Use this for initialization
	void Start () {
        maxHealth = 1000;
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isDead) TakeDamage(1);
		if(damaged)
        {
            //damageImage.color = flashColor;
        }
        else
        {
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth / maxHealth;
       // playerAudio.Play();
        if (currentHealth <= 0 && !isDead)
            Death();
    }

    void Death ()
    {
        isDead = true;
        //anim.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        //playerMovement.enabled = false;
    }
}
