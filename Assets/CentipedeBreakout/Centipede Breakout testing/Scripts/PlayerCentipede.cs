using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadeAnarchy;
using CentipedeBreakout;

namespace CentipedeBreakout
{
    public class PlayerCentipede : MonoBehaviour
    {
        public Rigidbody2D rb;
        public GameObject hit;
        private Vector3 playerMove;
        private float timer;
        private float gunTimer;
        public GameObject bullet;
        public GameObject health;
        private float iFrames;
        public SpriteRenderer sprite;
        private Animator animator;

        //movespeeds
        public float playerSpeedHorizontal;
        public float playerSpeedVertical;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            sprite = gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();


            if (animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", false);
            }

            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    //Debug.Log("I DONT UNDERSTAND COROUTINES?");
                    timer = 0;
                    StartCoroutine(Attack());
                }
            }

            gunTimer += Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift) && gunTimer >= 0.2)
            {
                //bject original, Vector3 position, Quaternion rotation
                Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                gunTimer = 0;
            }



            RaycastHit2D hit = Physics2D.Raycast(transform.position - Vector3.up * 0.2f, Vector2.up * 0.2f);

            iFrames += Time.deltaTime;
            if (hit.collider.gameObject.tag == "Centipede" && iFrames > 1)
            {
                StartCoroutine(FlashRed());
                EventManager.instance.HeartLost();
                iFrames = 0;
            }
        }


        /*
        public List<GameObject> hearts;
        private int heartsLeft = 3;

        public void DamageTaken()
        {
            heartsLeft -= 1;
            
            if (heartsLeft < 0)
            {
                Debug.Log("gameover");
            }
            else {
                Debug.Log("Piss" + hearts.Count);
                hearts[heartsLeft].SetActive(false); 
            }
        }
        */

        //Maybe delete this mess??
        public IEnumerator Attack()
        {
            //Debug.Log("WORK");
            //100s can exist atm
            GameObject currentHit = Instantiate(hit, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f,0), Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            Destroy(currentHit);
        }



        //will flash semi randomly, but it's fine
        public IEnumerator FlashRed()
        {
            for (int i = 0; i <= 2; i++) {
                sprite.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                sprite.color = Color.white;
                yield return new WaitForSeconds(0.1f);
            }
        }

        

        void Movement()
        {
            animator.SetBool("Walk", false);
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walk", true);
                playerMove += new Vector3(playerSpeedHorizontal / 30, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Walk", true);
                playerMove += new Vector3(-playerSpeedHorizontal / 30, 0, 0);
            }
            if (Input.GetKey(KeyCode.W) && transform.position.y <= -3)
            {
                animator.SetBool("Walk", true);
                playerMove += new Vector3(0, playerSpeedVertical / 30, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Walk", true);
                playerMove += new Vector3(0, -playerSpeedVertical / 30, 0);
            }


            rb.MovePosition(transform.position + playerMove);
            playerMove = Vector3.zero;
        }
    }
}