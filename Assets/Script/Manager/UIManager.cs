using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonPattern<UIManager>
{
    public Slider slider;

    // set initial health and max health
    public void SetHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // update health as needed
    public void UpdateHealth(float health)
    {
        slider.value = health;
    }

}
