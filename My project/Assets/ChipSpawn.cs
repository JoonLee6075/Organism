using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float timer;
    public GameObject chipPrefab;
    private Vector3 offset;
    public AudioClip spawnsound;
    public float timer2;
    public GameObject antPrefab;
    public GameObject antSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if(timer2 <= 0)
        {
            Instantiate(antPrefab, antSpawn.transform.position, antPrefab.transform.rotation);
            timer2 = 10;
        }

        if(timer <= 0)
        {
            var x = Random.Range(-2f, 2f);
            var y = Random.Range(-2f, 2f);
            offset = new Vector3(x, y, 0);
            Instantiate(chipPrefab, spawnPoint.position + offset, chipPrefab.transform.rotation);
            SoundManager.Instance.PlaySound(spawnsound);
            timer = 3;
        }
    }
}
