using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectTower : MonoBehaviour
{
    public bool pressed;
    Spawner spawn;
    public GameObject destroyButton;
    public List<GameObject> towers;

    void OnMouseDown()
    {
        pressed = true;
    }

    public void CancelSelection()
    {
        pressed = false;
    }

    public void DestroySelection()
    {
        var cost = towers[Tower1.towerID].GetComponent<Tower1>().cost;
        if (GameManager.instance.currency.CheckCurrency(cost))
        {
            GameManager.instance.currency.UsingCurrency(cost);
            GameObject tower = Instantiate(towers[Tower1.towerID], gameObject.transform.parent);
            tower.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (pressed)
        {
            destroyButton.SetActive(true);
        } else
        {
            destroyButton.SetActive(false);
        }
    }
}
