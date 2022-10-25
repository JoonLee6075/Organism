using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float timer;
    public GameObject chipPrefab;
    private Vector3 offset;
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
            var x = Random.Range(-2, 2);
            var y = Random.Range(-2, 2);
            offset = new Vector3(x, y, 0);
            Instantiate(chipPrefab, spawnPoint.position + offset, chipPrefab.transform.rotation);
            timer = 3;
        }
    }
}
