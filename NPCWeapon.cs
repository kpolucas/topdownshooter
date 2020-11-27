using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWeapon : MonoBehaviour
{
    // METER HEADERS    [Header("Current Health:")] etc
    // Meter en una clase weaponType o algo asi
    public int ammo = 10;
    public int cartridge = 15;
    public int damage = 10;
    public float fireRate = 1f;
    public float range = 6f;
    //  

    float elapsed;
    Transform closestEnemy;
    float fireCountdown = 0;

    Spot spot;
    Animator spotAnimator;

    void Start()
    {
        spot = gameObject.GetComponent<Spot>();
        spotAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (spot.hasNPC)
        {
            ScanEnemys();
            CanPlayerShoot();
        }
    }

    void CanPlayerShoot()
    {
            // disparo, la velocidad depende del fireRate
            if (closestEnemy != null && fireCountdown <= 0f && ammo > 0)
            {
                Shoot(closestEnemy);
                spotAnimator.SetTrigger("shoot");
                fireCountdown = 1 / fireRate;
            }
            fireCountdown -= Time.deltaTime;
    }

    void ScanEnemys()
    {
        // escaneo por enemigos cada 1s
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            closestEnemy = ClosestEnemyInsideRadius();
            elapsed = elapsed % 1f;
        }
    }

    Transform ClosestEnemyInsideRadius()
    {
        GameObject[] multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleEnemies)
        {
            // if inside viewRadius
            if (Vector3.Distance(go.transform.position, transform.position) < range)
            {
                float currentDistance = Vector3.Distance(transform.position, go.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    trans = go.transform;
                }
            }
        }
        return trans;
    }

    void Shoot(Transform _closestEnemy)
    {
        Vector3 closestEnemyDirection = (_closestEnemy.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, closestEnemyDirection);

        Debug.DrawRay(transform.position, (_closestEnemy.position - transform.position), color: Color.red, duration: 0.5f);
        if (hit.transform.tag == "Enemy")
        {
            hit.transform.Translate(closestEnemyDirection * 0.3f); // <-- deshardcodear fuerza del impacto
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
        ammo--;
    }

    private void OnDrawGizmos()
    { 
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
