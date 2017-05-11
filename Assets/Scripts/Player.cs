using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectilePrefab;
    public List<GameObject> Projectiles = new List<GameObject>();
    public GameObject powerprojectilePrefab;
    public List<GameObject> PowerProjectiles = new List<GameObject>();

    private float projectileVelocity;

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 200f;

    public bool grounded;
    public bool canDoubleJump;

    private Rigidbody2D rb2d;
    private Animator anim;
	
	void Start ()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        projectileVelocity = 3;

	}


    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(bullet);
        }

        for(int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBullet = Projectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if(bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
                }
            }
        }


        if (Input.GetButtonDown("Fire2"))
        {
            GameObject terraindestroy = (GameObject)Instantiate(powerprojectilePrefab, transform.position, Quaternion.identity);
            PowerProjectiles.Add(terraindestroy);
        }
        for (int i = 0; i < PowerProjectiles.Count; i++)
        {
            GameObject goBullet = PowerProjectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
            }
        }


                anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower);
                }
            }
        }
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        //Moving player
        rb2d.AddForce((Vector2.right * speed) * h);


        //Limit speed of player
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }
}
