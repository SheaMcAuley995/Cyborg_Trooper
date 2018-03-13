using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    float timeToSpawnEffect;
    public float effectSpawnRate = 10;
    public Transform bulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
    public Camera ShootyCam;

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
        Vector2 mousePosition = new Vector2(ShootyCam.ScreenToWorldPoint(Input.mousePosition).x,ShootyCam.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);

        if(Time.time >= timeToSpawnEffect)
        {
            Vector3 hitPos;

            if(hit.collider == null)
            {
                hitPos = ((mousePosition - firePointPosition).normalized  * 30) + firePointPosition;

            }else
            {
                hitPos = hit.point;
            }

            Effect(hitPos);
           // StartCoroutine("Effect");
            
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100, Color.cyan);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

    void Effect(Vector3 hitPos)
    {

        //Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform trail = Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation) as Transform;
        LineRenderer lr = trail.GetComponent<LineRenderer>();


        if (lr != null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);
        }
        Destroy(trail.gameObject, 0.02f);

        Transform clone = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.3f, 0.5f);
        clone.localScale = new Vector3(size, size, 0);
        //yield return 0;
        Destroy(clone.gameObject, 0.02f);
    }
}
