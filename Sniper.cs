using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    [SerializeField] FieldOfView fieldOfView;
    [SerializeField] float fov = 50f;
    [SerializeField] float viewDistance = 6f;

    GameObject[] multipleEnemies;
    Transform closestEnemy = null;
    float elapsed;


    void Start()
    {
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
            closestEnemy = GetClosestEnemy();
            if(closestEnemy != null)
            {
                isEnemyInsideFOV();
            }
        }
    }


    Transform GetClosestEnemy()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleEnemies)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }

    bool isEnemyInsideFOV()
    {
        if (Vector3.Distance(closestEnemy.position, transform.position) < viewDistance && 
            Vector3.Angle(transform.up, (closestEnemy.position - transform.position)) < fov/2)
        {
            Debug.Log("TRUE");
            return true;
        }
        else
        {
            Debug.Log("FALSE");
            return false;
        }
    }
}
