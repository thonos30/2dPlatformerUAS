using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float move;
    public AudioSource suaraMati;
    public float speed = 0.005f;
    private Rigidbody2D rb; 
    public float jump = 5f;
    private Animator Anime;
    public Transform[] Miror;
    public bool canTeleport;
    private bool canJump;
    public GameObject[] Enemy;
    public EnemyController[] EC;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        canTeleport = true;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")&&canJump)
        {
            Anime.SetTrigger("IsJump");
            rb.AddForce(new Vector2(0f,jump),ForceMode2D.Impulse);
            canJump = false;
        }
        if (move!=0 )
        {
            Anime.SetTrigger("IsRun");
        }
        else if (move == 0)
        {
            Anime.SetTrigger("IsIdle");
        }
        if(!Mathf.Approximately(0,move))
        {
            transform.rotation = -move > 0 ? Quaternion.Euler(0,180,0):Quaternion.identity;
        }

    }
     private void FixedUpdate() 
    {
        rb.velocity = new Vector2(move * speed,rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "tanah")
        {
            Anime.ResetTrigger("IsJump");
            canJump = true;
        }
        if(other.collider.name == "Miror 1"&& canTeleport)
        {
            transform.position = new Vector2(Miror[0].position. x, Miror[0]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 1.0f);
        }
        if(other.collider.name == "Miror 2"&& canTeleport)
        {
            transform.position = new Vector2(Miror[1].position. x, Miror[1]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 2.0f);
        }
        if(other.collider.name == "Miror 1 2"&& canTeleport)
        {
            transform.position = new Vector2(Miror[2].position. x, Miror[2]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 1.0f);
        }
        if(other.collider.name == "Miror 2 1"&& canTeleport)
        {
            transform.position = new Vector2(Miror[3].position. x, Miror[3]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 2.0f);
        }
        if(other.collider.name == "Miror 3 1"&& canTeleport)
        {
            transform.position = new Vector2(Miror[4].position. x, Miror[4]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 1.0f);
        }
        if(other.collider.name == "Miror 3 2"&& canTeleport)
        {
            transform.position = new Vector2(Miror[5].position. x, Miror[5]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 2.0f);
        }
        if(other.collider.name == "Miror 4 1"&& canTeleport)
        {
            transform.position = new Vector2(Miror[6].position. x, Miror[6]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 1.0f);
        }
        if(other.collider.name == "Miror 4 2"&& canTeleport)
        {
            transform.position = new Vector2(Miror[7].position. x, Miror[7]. position. y);
            Anime.SetTrigger("IsTeleport");
            canTeleport = false;
            Invoke("Teleport", 2.0f);
        }
        if(other.collider.tag == "Musuh")
        {
            Dead();
        }
        if(other.collider.tag == "Air")
        {
            Dead();
        }
    }

    void Teleport()
    {
        canTeleport = true;
    }
    void Dead()
    {
        suaraMati.Play();
        Anime.SetTrigger("IsDead");
        move = 0;
        Invoke("Mati",2.0f);
    }

    void Mati()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Enemy")
        {
            rb.AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            EC[0].Animation();
        }
        if(other.name == "Enemy 1")
        {
            rb.AddForce(new Vector2(0f,5f),ForceMode2D.Impulse);
            EC[1].Animation();
        }
    }
}
