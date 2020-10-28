using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    [SerializeField] FieldOfView pfFieldOfView;
    [SerializeField] float fov = 50f;
    [SerializeField] float viewDistance = 6f;
    FieldOfView fieldOfView;

    GameObject[] multipleEnemies;
    Transform closestEnemy = null;
    float elapsed;


    void Start()
    {
        fieldOfView = Instantiate(pfFieldOfView, Vector3.zero, Quaternion.identity);
        fieldOfView.viewDistance = viewDistance;
        fieldOfView.fov = fov;
    }

    void Update()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDirection(transform.up);

        // busco el mas cercano cada 1s
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            closestEnemy = GetClosestEnemyInsideFOV();
            if(closestEnemy != null)
            {
                Shoot(closestEnemy.position);
            }
        }
    }


    void Shoot(Vector3 closestEnemyPosition)
    {
        Vector3 closestEnemyDirection = (closestEnemyPosition - transform.position).normalized;
        Debug.DrawRay(transform.position, closestEnemyDirection, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, closestEnemyDirection);
        if (hit)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            enemy.TakeDamage(20);
            Debug.Log(enemy.health);
            Debug.Log(hit.collider.transform.position);
        }
    }


    Transform GetClosestEnemyInsideFOV()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleEnemies)
        {
            // if inside FOV
            if(Vector3.Distance(go.transform.position, transform.position) < viewDistance &&
                Vector3.Angle(transform.up, (go.transform.position - transform.position)) < fov/2)
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
}
