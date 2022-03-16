using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageTest : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;
    // Start is called before the first frame update
    void Start()
    { 
        foreach(GameObject item in itemPrefabs)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            Instantiate(item, transform.position, Quaternion.identity);
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
