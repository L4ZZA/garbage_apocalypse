using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static string LayerTag => "Player";

    [SerializeField]
    Text healthDisplay;
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
        healthDisplay.text = health.ToString();
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
        playerBody.velocity = new Vector2(input * speed, playerBody.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
