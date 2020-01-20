using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersMenu : MonoBehaviour
{
    public GameObject Place;

    public void Close(){
        this.gameObject.SetActive(false);
    }
    public void Build(TowerSettings settings){
        GameObject NewTower = new GameObject();
        Vector3 pos = Place.transform.transform.position;
        pos.z ++;
        NewTower.transform.position = pos;
        NewTower.name = "Tower";
        NewTower.AddComponent<CircleCollider2D>();
        SpriteRenderer spriteRenderer = NewTower.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = settings.Sprite;
        spriteRenderer.sortingOrder = 1;
        NewTower.AddComponent<TowerShoot>().Settings = settings;
        GetGameController._GetGameController.Balance -= settings.Price;
        GetGameController._GetGameController.UpdateUI();
        Place.GetComponent<TowerPlace>().Tower = NewTower;
        gameObject.SetActive(false);
    }
}
