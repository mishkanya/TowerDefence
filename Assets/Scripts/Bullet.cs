using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] 
    public Transform Target; 

    [HideInInspector] 
    public float Damage;
    private const float _speed = 3;
    private const float _AttackRadius = 0.1f;

    private void FixedUpdate() {
        if(Target != null){
            transform.Translate((Target.position - transform.position).normalized * Time.fixedDeltaTime * _speed);

            if(Mathf.Abs(Target.position.x - transform.position.x) < _AttackRadius && Mathf.Abs(Target.position.y - transform.position.y) < _AttackRadius)
                Attack(Target.GetComponent<Collider2D>());
        }
        else
            Destroy(gameObject);
    }

    private void Attack(Collider2D other) {
        if(other.tag == "Enemy"){
            other.GetComponent<Monster>().ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
