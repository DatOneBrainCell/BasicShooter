using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void SetMaxHealthOnHealthBar(int health) {

        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    public void SetHealthOnHealthBar(int health) {

        healthSlider.value = health;
    }

}
