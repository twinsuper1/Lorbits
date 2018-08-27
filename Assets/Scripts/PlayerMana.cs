using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    //https://unity3d.com/learn/tutorials/projects/survival-shooter/player-Mana
    public float maxMana = 1000;
    public float currentMana;
    public Slider ManaSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;

    //bool hasMana = false;
    bool damaged;

    // Use this for initialization
    void Start()
    {
        maxMana = 1000;
        currentMana = 0;
    }

    // Update is called once per frame
    void Update()
    {

        regenMana(1F);

        if (currentMana >= maxMana) currentMana = maxMana;
       
        if (damaged)
        {
            //damageImage.color = flashColor;
        }
        else
        {
            //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (Input.GetKeyDown(KeyCode.Space) && currentMana>=300)
        {
            currentMana = (currentMana-300)/ maxMana; 
        }
    }

    public void regenMana(float amount)
    {
        currentMana += amount;
        ManaSlider.value = currentMana / maxMana;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
            hasMana = true;
        }
        else
        {
            hasMana = false; 
        }
    }



    /*public void TakeDamage(int amount)
    {
        damaged = true;
        currentMana -= amount;
        ManaSlider.value = currentMana / maxMana;
        // playerAudio.Play();
        if (currentMana <= 0 && !isDead)
            Death();
    }

    void Death()
    {
        isDead = true;
        //anim.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        //playerMovement.enabled = false;
    }*/
}
