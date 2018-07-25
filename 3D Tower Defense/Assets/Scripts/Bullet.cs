using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target;
    public Transform Target {
        get { return _target; }
        set { _target = value; }
    }

    public int damage = 15;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform target) {
        _target = target;
    }
	
	// Update is called once per frame
	void Update () {
        if (_target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame / 5f, Space.World);
        transform.LookAt(_target);
	}

    void HitTarget () {
        GameObject bulletEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(bulletEffect, 5f);

        if (explosionRadius > 0) {
            Explode();
        } else {
            Damage(_target);
        }
        
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
