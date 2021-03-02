using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public float speed;
    public int damage = 5;
    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {

        transform.Translate(RandPoint(0, 2) * speed *Time.deltaTime );

        Destroy(gameObject, 5f);

        
    }

    public Vector3 RandPoint(float min, float max)
    {
        Vector3 test = Random.insideUnitSphere * (4 * Random.Range(min, max));
        return test;
    }



}
