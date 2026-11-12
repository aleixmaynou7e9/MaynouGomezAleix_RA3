using UnityEngine;

public class SatyrShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1.5f; 
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        ProjectilePool.Instance.GetProjectile(firePoint.position, transform.rotation);
    }
}
