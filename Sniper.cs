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
        //if (elapsed >= 1f)
        if (true)
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
        //https://www.youtube.com/watch?v=THnivyG0Mvo&t=297s
        RaycastHit hit;
        //Debug.DrawLine(transform.position, closestEnemyPosition, Color.red);
        if (Physics.Raycast(transform.position, closestEnemyPosition, out hit)) // <---- NO anda el if WHY?
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("70DMG");
                enemy.TakeDamage(70);
            }
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
