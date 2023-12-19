using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyAllCubesOnTrigger : MonoBehaviour
{
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            foreach (GameObject cube in cubes)
            {
                Destroy(cube);
            }
        }       
        
    }
}
