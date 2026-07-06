using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image hpbarForegroundImg;

    public Gradient gradient;

    public float maxHealth = 1;
    private float currentHealth;

    private void Start()
    {
        //set currenthealth to the max health
        currentHealth = maxHealth;
        //set the hp bar foreground's fill amount to the max health value
        hpbarForegroundImg.fillAmount = maxHealth;
        //set the colour of the gradient based on the max health value
        gradient.Evaluate(maxHealth);  
    }

    //create the method for taking damage here

   
    //create the method for healing here


    //additional method to do something once game ends/player dies



}
