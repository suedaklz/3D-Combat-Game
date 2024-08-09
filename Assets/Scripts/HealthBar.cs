using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    private float lerpSpeed = 0.05f;

    private void Update()
    {
        if(healthSlider.value != easeHealthSlider.value)
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);

    }
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        easeHealthSlider.maxValue = maxHealth;
        easeHealthSlider.value = maxHealth;
        
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
