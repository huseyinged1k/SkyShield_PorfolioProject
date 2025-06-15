using UnityEngine;

public static class ProjectileFactory
{
    public static void SpawnProjectile(GameObject projectilePrefab,Vector3 position, Transform target)
    {
        if (projectilePrefab == null) return;
        var obj = GameObject.Instantiate(projectilePrefab, position, Quaternion.identity);
        obj.GetComponent<Projectile>().Init(target);
    }
}