using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public int maxPoolSize = 20; 
    public int startPoolSize = 10; 

    private List<GameObject> bullets; 
    private int currentPoolCount; 

    private void Awake()
    {
        
        bullets = new List<GameObject>();

        for (int i = 0; i < startPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false); 
        bullets.Add(bullet);
        currentPoolCount++;
        return bullet;
    }

    public GameObject TryGetFromPool()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy) 
            {
                return bullet;
            }
        }

        
        if (currentPoolCount < maxPoolSize)
        {
            return CreateBullet(); 
        }

        return null; 
    }
}