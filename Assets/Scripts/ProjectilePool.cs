using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int initialSize = 20;

    private Stack<Projectile> pool = new Stack<Projectile>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < initialSize; i++)
        {
            Projectile projectile = CreateProjectile();
            pool.Push(projectile);
        }
    }

    private Projectile CreateProjectile()
    {
        Projectile newProjectile = Instantiate(projectilePrefab, transform);
        newProjectile.gameObject.SetActive(false);
        return newProjectile;
    }

    public Projectile GetProjectile(Vector3 position, Quaternion rotation)
    {
        Projectile projectileToUse = null;

        while (pool.Count > 0 && projectileToUse == null)
        {
            projectileToUse = pool.Pop();
        }

        if (projectileToUse == null)
        {
            projectileToUse = CreateProjectile();
        }

        projectileToUse.transform.position = position;
        projectileToUse.transform.rotation = rotation;
        projectileToUse.gameObject.SetActive(true);
        return projectileToUse;
    }

    public void ReturnProjectile(Projectile projectile)
    {
        if (projectile == null) return;

        projectile.gameObject.SetActive(false);
        projectile.transform.SetParent(transform);
        pool.Push(projectile);
    }
}