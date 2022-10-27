using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetPosition;
    private float lerpDuration = 120f;
    private float startValue = 0;
    private float timer = 2.1f;

    void Start()
    {
        targetPosition = this.transform;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
       
    }

    IEnumerator Move()
    {
        float timeElapsed = 0;
        var target = targetPosition.position + new Vector3(0, -8, 0);
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, target, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Chip")
        {
            Debug.Log("asdf");
           
        }

        if(collision.gameObject.tag == "Ant")
        {
            Destroy(collision.gameObject);
        }
    }
}
