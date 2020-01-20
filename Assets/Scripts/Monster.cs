using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSettings Settings;
    private float _health;

    private bool _startAttack = false;

    private Transform[] _points;
    private int _pointID = 0;
    
    Transform _transform;
    private void Start()
    {
        _health = Settings.Health;
        _points = GetGameController._GetGameController._GetPoints;
        _transform = GetComponent<Transform>();
    }
    private void FixedUpdate() {
        if(!_startAttack)
            Move();
    }
    private void Move(){
        if(_pointID < _points.Length)
        {
            _transform.Translate((_points[_pointID].position - _transform.position).normalized * Time.fixedDeltaTime * Settings.Speed);
            
            if(_points[_pointID].position.x - _transform.position.x < 1 && _points[_pointID].position.y - _transform.position.y < 1)
                _pointID++;
        }
        if(_pointID == _points.Length &&  !_startAttack)
        {
            _startAttack = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack(){
        while(_startAttack){
            GetGameController._GetGameController.ApplyDamage = Settings.Damage;
            yield return new WaitForSeconds(1);
        }
    }
    private void Death(){
        StopCoroutine(Attack());
        GetGameController._GetGameController.Balance += Settings.MoneyForKill;
        GetGameController._GetGameController.UpdateUI();
        Destroy(gameObject);
    }
    public void ApplyDamage(float damage){
        _health -= damage;
        if(_health <= 0)
            Death();
    }
}
