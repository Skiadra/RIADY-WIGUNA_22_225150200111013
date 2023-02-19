using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Spawner : MonoBehaviour
{
    //tower id to spawn
    int spawnId = -1;
    //list of towers prefabs
    public List<GameObject> towers;
    public AudioSource effect;
    public AudioSource build;
    public Transform spawnTowerRoot;
    //tower highlight
    public List<Image> towersUI;
    //spawn point on tilemaps
    public Tilemap spawnTilemap;

    void Update()
    {
        if (spawnId != -1)
        {
            DetectSpawnPoint();
        }
    }

    void DetectSpawnPoint()
    {
        //detect if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //get mouse position
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get positition of the cell
            var cellPos = spawnTilemap.WorldToCell(mousePosition);
            //get center of the cell
            var centerCell = spawnTilemap.GetCellCenterWorld(cellPos);
            //check if we can spawn in that cell
            if (spawnTilemap.GetColliderType(cellPos) == Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost();
                if (GameManager.instance.currency.CheckCurrency(TowerCost()))
                {
                    GameManager.instance.currency.UsingCurrency(towerCost);
                    SpawnTower(centerCell);
                    spawnTilemap.SetColliderType(cellPos, Tile.ColliderType.None);
                } else
                {
                    Debug.Log("Gak cukup bang!");
                }
            }
            //if yes, spawn and disable collider
            //if no do nothing
        }
    }

    public int TowerCost()
    {
        switch(spawnId)
        {
            case 0 : return towers[0].GetComponent<Tower1>().cost;
            case 1 : return towers[1].GetComponent<Tower1>().cost;
            case 2 : return towers[2].GetComponent<Tower1>().cost;
            default : return -1;
        }
    }
    void SpawnTower(Vector3 pos)
    {
        GameObject tower = Instantiate(towers[spawnId], spawnTowerRoot);
        tower.transform.position = pos + new Vector3( 0, .1f, 0);
        build.Play();

        DeselectTower();
    }
    public void SelectTower(int id)
    {
        DeselectTower();
        spawnId = id;
        Tower1.towerID = spawnId;
        towersUI[spawnId].color = Color.white;
        effect.Play();
    }

    public void DeselectTower()
    {
        spawnId = -1;
        foreach(var t in towersUI)
        {
            t.color = new Color(1, 1, 1, .5f);
        }
    }
}
