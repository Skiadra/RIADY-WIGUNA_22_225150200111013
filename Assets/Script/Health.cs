using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Text healthText;
    public GameObject gameOverUI;
    bool lost = false;
    public static int healthCount;
    public int defaultHealthCount = 5;

    public void Init()
    {
        healthCount = defaultHealthCount;
    }

    void Start()
    {
        InvokeRepeating("CheckHealth", 0f, .2f);
    }

    public void LosingHealth()
    {
        if (healthCount < 1)
            return;

        healthCount --;
        healthText.text = healthCount.ToString();
    }

    public void CheckHealth()
    {   
        if (lost == false)
            healthText.text = healthCount.ToString();
        if (healthCount < 1 && lost == false)
        {
            gameOverUI.SetActive(true);
            lost = true;
        }
        if (healthCount < 1)
            return;
    }

}
