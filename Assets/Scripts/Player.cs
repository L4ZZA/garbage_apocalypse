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
    GameObject losePanel;
    [SerializeField]
    GameObject dashShadow;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    int health = 1;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip dashSound;

    float input;
    public float startDashTime;
    public float extraSpeed;
    public bool isDashing { get; private set; }
    private float dashTime;

    Rigidbody2D playerBody;
    Animator animator;
    AudioSource audioSource;


    const string RUNNING_PARAM_NAME = "isRunning";

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        if(input != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
            {
                audioSource.clip = dashSound;
                audioSource.Play();
                speed += extraSpeed;
                isDashing = true;
                dashTime = startDashTime;
                Instantiate(dashShadow, transform.position, Quaternion.identity);
            }

            if (dashTime <= 0 && isDashing)
            {
                speed -= extraSpeed;
                isDashing = false;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(input * speed, playerBody.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        audioSource.clip = hitSound;
        audioSource.Play();
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            losePanel.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();
    }
}
