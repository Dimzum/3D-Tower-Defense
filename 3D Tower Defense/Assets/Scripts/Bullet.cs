using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target;

    public float speed = 30f;
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
	}

    void HitTarget () {
        GameObject bulletEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(bulletEffect, 2f);

        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
