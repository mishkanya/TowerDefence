using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Pause;
    public MonsterSettings[] Monsters;
    private float _tideTime;
    private bool _tideIsActive = false;
    private Transform _transform;
    private void Start() {
        _tideTime = GetGameController._GetGameController.Settings.TimeForTide;
        _transform = transform;
        
    }
    public void TideActive(bool enable){
        if(enable && !_tideIsActive){
            StartCoroutine(Spawn());
            _tideIsActive = true;
        }
        else if(!enable){
            _tideIsActive = false;
            StopCoroutine(Spawn());
        }
    }
    private IEnumerator Spawn(){
        StartCoroutine(GetGameController._GetGameController.Timer());
        for(float i = _tideTime; i > 0; i -= Pause)
        {
            yield return new WaitForSeconds(Pause);

            MonsterSettings newSettings = Monsters[Random.Range(0 ,Monsters.Length - 1)];

            GameObject NewMonster = new GameObject();
            NewMonster.transform.position = transform.position;
            NewMonster.name = "monster";
            NewMonster.tag ="Enemy";
            NewMonster.AddComponent<CircleCollider2D>();
            SpriteRenderer spriteRenderer = NewMonster.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSettings.Sprite;
            NewMonster.AddComponent<Monster>().Settings = newSettings;
        }
        _tideIsActive = false;
    }
}
