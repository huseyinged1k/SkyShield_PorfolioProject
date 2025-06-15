using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15f;
    private Transform target;

    public void Init(Transform t)
    {
        target = t;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}