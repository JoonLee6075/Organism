using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShoes : MonoBehaviour
{
    public float timer = 1;
    public GameObject shoes;
    private Vector3 offset;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 15;
            var x = Random.Range(-8, 8);
            offset = new Vector3(x, 0, 0);
            Instantiate(shoes, spawnPoint.position + offset, shoes.transform.rotation);
            Debug.Log(offset);
            
        }
    }
}
