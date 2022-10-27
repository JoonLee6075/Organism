using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rb;
    public GameObject chip;
    public bool isEating = false;
    public float rotationModifier;
    private float speed = 2f;
    private float timer = 2f;
    private float lifeSpand = 15;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        chip = GameObject.FindGameObjectWithTag("Chip");

    }
    void Update()
    {
        lifeSpand -= Time.deltaTime;
        if(lifeSpand <= 0)
        {
            Destroy(gameObject);
        }
        if(isEating == true)
        {
            timer -= Time.deltaTime;
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            if(timer < 0)
            {
                isEating = false;
                timer = 2;
            }
        }
        if (isEating == false)
        {
            gameObject.transform.position += transform.up * Time.deltaTime * 2;

            if (chip == null)
            {
                chip = GameObject.FindGameObjectWithTag("Chip");
                
            }
        }
    }

    private void FixedUpdate()
    {
        if (chip != null && isEating == false)
        {
            Vector3 vectorToTarget = chip.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle + 270, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Chip")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Eaten", true);
            isEating = true;
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<AntSpawn>().Spawn();
            Debug.Log("spawn");
            

        }
    }

}