using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public Text currencyText;
    public AudioSource plusing;
    public static int currencyCount;
    public float moneyTimer;
    float timer;
    public int defaultCurrencyCount;

    public void Init()
    {
        currencyCount = defaultCurrencyCount;
        timer = moneyTimer;
        UpdateUI();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = moneyTimer;
            currencyCount += 2;
            plusing.Play();
        }
        UpdateUI();
    }
    public void AddCurrency(int value)
    {   
        currencyCount += value;
        UpdateUI();
    }

    public void UsingCurrency(int value)
    {
        if (CheckCurrency(value))
        {
            currencyCount -= value;
            UpdateUI();
        }
    }

    public bool CheckCurrency(int val)
    {
        if (currencyCount >= val)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void UpdateUI()
    {
        currencyText.text = currencyCount.ToString();
    }
}
