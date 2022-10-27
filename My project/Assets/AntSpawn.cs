using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject ant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int ChooseSpawn()
    {
        return Random.Range(0, spawnPoints.Length);
    }

    public void Spawn()
    {
        Instantiate(ant, spawnPoints[ChooseSpawn()].transform.position, ant.transform.rotation);
    }
}
