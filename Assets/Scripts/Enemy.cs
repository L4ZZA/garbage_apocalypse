using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float minSpeed;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    Player playerScript;
    [SerializeField]
    GameObject explosion;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag(Player.LayerTag).GetComponent<Player>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Player.LayerTag)
        {
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.tag == "Ground")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
