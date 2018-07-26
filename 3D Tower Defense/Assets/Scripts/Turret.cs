using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform _target;
    private Enemy _targetEnemy;

    [Header("General")]
    public float range = 5f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 15;
    public float slowPercentage = .25f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (_target == null) {
            if (useLaser) {
                if (lineRenderer.enabled) {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser) {
            Laser();
        } else {
            if (fireCountdown <= 0f) {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
	}
    
    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            _target = nearestEnemy.transform;
            _targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else {
            _target = null;
        }
    }

    void LockOnTarget() {
        // Target lock on
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Lerp smoothes the rotation (helps when changing to a new target)
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser() {
        /* DAMAGE */
        _targetEnemy.EnemyStats.TakeDamage(damageOverTime * Time.deltaTime);
        _targetEnemy.EnemyController.Slow(slowPercentage);

        /* GRAPHICS COMPONENT */
        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, _target.position);

        // Get direction of enemy to turret
        Vector3 dir = firePoint.position - _target.position;
        // Set position of impact effect
        impactEffect.transform.position = _target.position + dir.normalized;
        // Set direction of impact effect towards the turret
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void Shoot() {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.Seek(_target);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
