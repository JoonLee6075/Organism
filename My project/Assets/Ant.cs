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

    public float rotationModifier;
    private float speed = 2f;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        chip = GameObject.FindGameObjectWithTag("Chip");

    }
    void Update()
    {
       
        
        gameObject.transform.position += transform.up * Time.deltaTime * 2;

        if(chip == null)
        {
            GameObject.FindGameObjectWithTag("Chip");
        }
    }

    private void FixedUpdate()
    {
        if (chip != null)
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

        }
    }

}