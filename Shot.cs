using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class Shot : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float reloadTime;
    public float timeBetweenShots;
    public int magazineSize;
    public int bulletPerTap;
    public float bulletSpeed = 5f;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public GameObject bulletPrefab = null;
    public Transform bulletSpawn;


    public Vector3 direction;

    bool shooting;
    bool readyToShoot;
    bool reloading;


    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //public GameObject muzzleFlash;  Animation for muzzleFlash dies not work

    //    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }


    private void Update()
    {
        MyInput();
    }


    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) { Reload(); }


        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            bulletsShot = bulletPerTap;
            Shoot(); 
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = bulletSpawn.transform.forward + new Vector3(x, y, 0);

        //Debug.DrawRay(fpsCam.transform.position, direction, Color.green);

        if (Physics.Raycast(bulletSpawn.transform.position, direction, out rayHit, range, whatIsEnemy))
        {


            //if (rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage));
        }

        GameObject test = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        test.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed);

        bulletsLeft--;
        bulletsShot--;

//Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }


    private void Reload()
    {
        reloading = true;
        Invoke("ReloadeFinished", reloadTime);
    }

    private void ReloadeFinished()
    {
        bulletsLeft = magazineSize;

        reloading = false;
    }

}
