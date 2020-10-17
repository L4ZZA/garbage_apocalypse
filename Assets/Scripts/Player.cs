using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static string LayerTag => "Player";

    [SerializeField]
    float speed = 1;
    [SerializeField]
    int health = 1;

    float input;

    Rigidbody2D playerBody;
    Animator animator;


    const string RUNNING_PARAM_NAME = "isRunning";

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input != 0)
        {
            animator.SetBool(RUNNING_PARAM_NAME, true);
        }
        else
        {
            animator.SetBool(RUNNING_PARAM_NAME, false);
        }

        if (input > 0)
        {
            // rotate right
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (input < 0)
        {
            // zero rotation (so face left)
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(input * speed * Time.deltaTime, playerBody.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
