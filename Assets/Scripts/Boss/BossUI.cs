using UnityEngine;
using UnityEngine.UI;


public class BossUI : MonoBehaviour
{

    public Slider slider;

    public BossHealth boss;


    void Start()
    {
        slider.maxValue = boss.maxHealth;
    }


    void Update()
    {
        slider.value = boss.GetHealth();
    }

}