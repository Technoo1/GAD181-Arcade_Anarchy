using CentipedeBreakout;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CentipedeBreakout;

namespace CentipedeBreakout
{
    public class Hit : MonoBehaviour
    {
        private Vector3 edgeOfHit = new Vector3(1, 0, 0);

        //Each hit can kill up to 5 segments on a centipede
        //so I'm maxing it a one
        //this means if you hit 2 seperate 'pedes
        //only one loses a head
        //potentially benfitting an experienced player going for points
        private bool killedAHead = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debugging();
        }


        void Debugging()
        {
            Debug.DrawLine(transform.position + edgeOfHit, transform.position + edgeOfHit + new Vector3(0.1f, 0, 0));
            Debug.DrawLine(transform.position - edgeOfHit, transform.position - edgeOfHit + new Vector3(-0.1f, 0, 0));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("STEP 1");
            if (collision.GetComponent<SegmentBody>())
            {
                collision.GetComponent<SegmentBody>().fall = false;
                Debug.Log("STEP 2");

                if (collision.OverlapPoint(transform.position + edgeOfHit))
                {
                    collision.GetComponent<SegmentBody>().centipedeHorizontalAngle = 1;
                }
                else if (collision.OverlapPoint(transform.position - edgeOfHit))
                {
                    collision.GetComponent<SegmentBody>().centipedeHorizontalAngle = -1;
                }
                else if (Mathf.Abs(collision.GetComponent<SegmentBody>().centipedeHorizontalAngle) == 1)
                {
                    collision.GetComponent<SegmentBody>().centipedeHorizontalAngle *= 0.3f;
                    Debug.Log("STEP 3");
                }
                if (killedAHead == false)
                {
                    collision.GetComponent<Segment>().Death();
                    killedAHead = true;
                }
            }
        }
    }
}