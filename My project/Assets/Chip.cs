using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 8)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            timer = 100;
        }
    }
}
