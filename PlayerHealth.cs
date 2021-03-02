using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public float immortalTime = 3f;
    private float timer = 0f;
    [SerializeField] bool immortal = false;

    private void Update()
    {
        if (immortal)
        {
            timer += Time.deltaTime;
            print(timer);
            if (timer > immortalTime)
            {
                print(timer + "Test2");
                immortal = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "enemy")
        {
            if (!immortal)
            {
                int enemyDmg = collision.gameObject.GetComponent<EnemyMovement>().enemyDmg;
                health = health - enemyDmg;
                immortal = true;
                if (health<= 0)
                    {
                        Destroy(gameObject);
                    }
                if (health > 0) { return; }
            }
        }
    }

}
