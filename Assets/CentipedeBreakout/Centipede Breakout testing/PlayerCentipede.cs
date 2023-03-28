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