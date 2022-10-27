using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public GameObject chip;
    public float timer2;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if(timer2 <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if(timer < 8)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            timer = 100;
        }
    }
    public void DestroyChip()
    {
        Destroy(gameObject);
    }

  
}
