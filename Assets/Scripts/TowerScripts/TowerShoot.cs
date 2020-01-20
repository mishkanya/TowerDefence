using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public TowerSettings Settings;

    private Transform _aim;
    private CircleCollider2D _collider;
    private void Start() {
        _collider = GetComponent<CircleCollider2D>();

        _collider.radius = Settings.AttackDistance;

        StartCoroutine(Shoots());
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" && _aim != null){
            _aim = other.GetComponent<Transform>();
        }
    }
    private IEnumerator Shoots(){
        while(true){
            if(_aim != null){
                float delta = (transform.position - _aim.position).magnitude;
                if(delta <= Settings.AttackDistance){
                    Bullet bullet = Instantiate(Settings.Bullet, transform.position, transform.rotation).GetComponent<Bullet>();
                    bullet.Target = _aim;
                    bullet.Damage = Settings.Damage;
                    yield return new WaitForSeconds(Settings.ShootInterval);
                }
                else
                {
                    _aim = null;
                }
            }
            else{
                yield return new WaitForSeconds(0.5f);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Settings.AttackDistance);
                foreach(Collider2D col in colliders){
                    if(col.tag == "Enemy")
                    {
                        _aim = col.gameObject.transform;
                        break;
                    }
               }
            }
        }
    }
}
