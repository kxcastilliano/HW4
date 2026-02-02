using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerrb;
    public float flypower = 7f;
    public AudioSource flysound;
    public delegate void PlayerDiedDelegate();
    public static event PlayerDiedDelegate OnPlayerDied;
    public AudioSource hitsound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerrb.velocity = Vector2.up * flypower;
            flysound.Play();
        }

    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            OnPlayerDied.Invoke();
            hitsound.Play();
            Debug.Log("Hit");
        }
        Debug.Log("Player Hit");
    }
}
