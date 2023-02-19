using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public Text indicator;
    void Start()
    {
        InvokeRepeating("UpdateHealth", 0f, .1f);
    }

    void UpdateHealth()
    {
        indicator.text = BossBehaviour.health.ToString();
    }

}
