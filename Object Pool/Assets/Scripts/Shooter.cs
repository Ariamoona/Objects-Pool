using UnityEngine;

public class Shooter : MonoBehaviour
{
    public BulletPool bulletPool; 
    public Transform firePoint; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = bulletPool.TryGetFromPool();
        if (bullet != null) 
        {
            bullet.transform.position = firePoint.position; 
            bullet.transform.rotation = firePoint.rotation; 
            bullet.SetActive(true); 
        }
    }
}