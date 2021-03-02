using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody myRb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int life = 5;

    public PlayerController thePlayer = null;
    public int enemyDmg = 5;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
    }

    private void FixedUpdate()
    {
        myRb.velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Coll");
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("bullet");
            int dmg = collision.gameObject.GetComponent<BulletController>().damage;
            life = life - dmg;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
