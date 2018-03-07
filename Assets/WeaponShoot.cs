using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform bulletTrailPrefab;


    float timeToFire = 0;
    Transform firePoint;


    private void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("NO SHOOOOT");
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Shoot();
        if(fireRate == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetMouseButton(0) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	
	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        Effect();
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100, Color.cyan);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

    void Effect()
    {
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
