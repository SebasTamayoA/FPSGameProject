using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class StaminaBar : MonoBehaviour
{

    public Slider staminaSlider;
    public float maxStamina = 100f;
    private float currentStamina;
    private float regenerateRateStaminaTime = 0.1f;
    private float regenerateAmount = 2f;
    private float losingStaminaTime = 0.1f;



    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }


    public void UseStamina(float amount)
    {
        if (currentStamina - amount >= 0)
        {
            StartCoroutine(LosingStaminaCoroutine(amount));
            StartCoroutine(RegenerateStaminaCoroutine());
        }
        else
        {
            Debug.Log("No tenemos Stamina");
        }
    }

    IEnumerator LosingStaminaCoroutine(float amount)
    {
        while (currentStamina >= 0)
        {
            currentStamina -= amount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(losingStaminaTime);
        }

        FindObjectOfType<FirstPersonController>().m_IsWalking = true;
    }

    IEnumerator RegenerateStaminaCoroutine()
    {
        yield return new WaitForSeconds(regenerateRateStaminaTime);
        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(regenerateRateStaminaTime);
        }
    }
}