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

        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();


            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                if (timer >= 1)
                {

                    Debug.Log("I DONT UNDERSTAND COROUTINES?");
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
            if (hit.collider.gameObject.tag == "Centipede" && iFrames > 2)
            {
                DamageTaken();
                iFrames = 0;
            }
        }

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

        //Maybe delete this mess??
        public IEnumerator Attack()
        {
            Debug.Log("WORK");
            //100s can exist atm
            GameObject currentHit = Instantiate(hit, gameObject.transform, false);
            yield return new WaitForSeconds(0.4f);
            Destroy(currentHit);
        }

        
        
        void Movement()
        {
            if (Input.GetKey(KeyCode.D))
            {

                playerMove += new Vector3(0.06f, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {

                playerMove += new Vector3(-0.06f, 0, 0);
            }
            if (Input.GetKey(KeyCode.W) && transform.position.y <= -3)
            {

                playerMove += new Vector3(0, 0.03f, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerMove += new Vector3(0, -0.03f, 0);
            }
            if (Input.GetKey(KeyCode.None)) { }

            

            rb.MovePosition(transform.position + playerMove);
            playerMove = Vector3.zero;
        }
    }
}