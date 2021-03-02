using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnPickUpController : MonoBehaviour
{
    private Collider collider;
    private List<GameObject> gOs = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        gOs.Add(other.gameObject);
        foreach (GameObject gameO in gOs)
        {
            Debug.Log(gameO);
            gameO.GetComponent<Material>().SetColor(gameO.name, Color.white );
        }
    }
}
