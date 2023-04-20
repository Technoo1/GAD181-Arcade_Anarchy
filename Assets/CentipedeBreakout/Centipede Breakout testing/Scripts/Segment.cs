using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using CentipedeBreakout;


namespace CentipedeBreakout
{

    public class Segment : MonoBehaviour
    {
        public GameObject attachedHead;
        public int health = 5;
        public Renderer ren;

        //a scirpt
        //on loaded scnee
        //set active

        // Start is called before the first frame update
        void Start()
        {
            ren = gameObject.GetComponent<Renderer>();
        }

        void OnMouseDown()
        {
            Debug.Log(gameObject + "Object clicked");
            attachedHead.GetComponent<SegmentBody>().DeadSegment(gameObject);

            Debug.Log("Murder");
            Destroy(gameObject);
        }

        //Would work 10* better if bullet detects segment but segment
        //is a trigger and triggers can't detect other triggers?
        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("PEWPEPWPEW");
            if (collision.gameObject.tag == "CBBullet")
            {
                gameObject.GetComponent<Segment>().LoseHealth();
            }
        }
        */

        public void Death()
        {
            //Needs an attached head if not dying it's because it hasn't got an attached head
            attachedHead.GetComponent<SegmentBody>().DeadSegment(gameObject);

            //Debug.Log("Murder");
            Destroy(gameObject);
        }

        public void LoseHealth()
        {
            health -= 1;

            switch (health)
            {
                case 4:
                    {
                        ren.material.SetColor("_Color", new Vector4(1, 1, 1, 1));
                        break;
                    }
                case 3:
                    {
                        ren.material.SetColor("_Color", new Vector4(1, 0.75f, 0.75f, 1));
                        break;
                    }
                case 2:
                    {
                        ren.material.SetColor("_Color", new Vector4(1, 0.5f, 0.5f, 1));
                        break;
                    }
                case 1:
                    {
                        ren.material.SetColor("_Color", new Vector4(1, 0.25f, 0.25f, 1));
                        break;
                    }
                case 0:
                    {
                        Death();
                        break; 
                    }
                default:
                    {
                        Death();
                        Debug.Log("HEY LISTEN");
                        break;
                    }
            }
        }


    }
}