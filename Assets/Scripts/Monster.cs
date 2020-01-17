using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSettings Settings;
    private float _health;
    private float _damage;
    private float _speed;

    private bool _startAttack = false;

    private Transform[] _points;
    private int _pointID = 0;
    
    Transform _transform;
    private void Awake() {
       _health = Settings.Health;
       _speed = Settings.Speed;
       _damage = Settings.Damage;
    }
    private void Start()
    {
        _points = GetPoints._GetPoints;
        _transform = GetComponent<Transform>();
    }
    private void FixedUpdate() {
        Move();
    }
    private void Move(){
        if(_pointID < _points.Length)
        {
            _transform.Translate((_points[_pointID].position - _transform.position).normalized * Time.fixedDeltaTime * _speed);
            
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
            GetGameController._GetGameController.ApplyDamage = _damage;
            yield return new WaitForSeconds(1);
        }
    }
}
