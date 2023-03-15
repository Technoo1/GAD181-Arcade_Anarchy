using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using CentipedeBreakout;
using System.Linq;
using System;

namespace CentipedeBreakout
{
    public class SegmentBody : Segment
    {
        //tracks how far apart each body segment is and the values where it can be.
        private float distanceMoved;
        //public Vector2[] headPositionPrevious;
        public List<Vector2> headPositionPrevious = new List<Vector2>();
        private Vector3 previousFramePosition;


        //allows you to edit how long a centipede is, on start.
        public int numberOfbodySegments;
        public GameObject bodyPrefab;
        public float distanceBetweenSegments;

        private GameObject[] bodySegments;


        //A counter for where the most recently updated value is, ++ is oldest, -- is newest
        private int startOfArray = 1;
        private int beforeStartOfArray;

        // the code for collision and movemovent
        public GameObject leftWall;
        public GameObject roof;
        public GameObject rightWall;
        public GameObject floor;
        public GameObject hit;

        private Collider2D collider;
        private Rigidbody2D rb;

        public bool fall;
        public float centipedeHorizontalAngle = 0.1f;
        public float centipedeSpeedFall;
        public float centipedeSpeedRise;
        public float centipedeSpeedHorizontal;

        public SegmentBody newHead;








        // Start is called before the first frame update
        void Start()
        {
            //rb = gameObject.AddComponent<Rigidbody2D>();

            if (distanceBetweenSegments == 0)
            {
                distanceBetweenSegments = 0.1f;
            }



            bodySegments = new GameObject[numberOfbodySegments];
            //Creates body parts and tells them what head they are attached to
            for (int i = 0; i < numberOfbodySegments; i++)
            {
                if (bodySegments[i] == null)
                {
                    bodySegments[i] = Instantiate(bodyPrefab, new Vector3(-3000, 3000, 0), Quaternion.identity);
                }
                //attached head is called to tell the head if the body part dies
                //Without it the body part does not know which head it belongs to.
                bodySegments[i].GetComponent<Segment>().attachedHead = gameObject;
            }
            attachedHead = gameObject;

            for (int i = 0; i <= bodySegments.Length * 10 - 1; i++)
            {
                headPositionPrevious.Add(new Vector2(1000, 0));
            }

        }

        // Update is called once per frame
        void Update()
        {
            //WASDTest();

            Fall();
            HorizontalMove();
            UpdatePreviousPositions();
            DebugVisual();


            int i = 1;
            foreach (var item in bodySegments)
            {
                int x = 0;
                if (startOfArray + i * 10 > bodySegments.Length * 10 - 1)
                {
                    x = startOfArray + i * 10 - bodySegments.Length * 10;
                }
                else
                {
                    x = startOfArray + i * 10;
                }
                item.transform.position = headPositionPrevious[x];
                i++;
            }

            previousFramePosition = transform.position;
        }

        private void DebugVisual()
        {

            for (int i = 0; i < bodySegments.Length * 10 - 1; i++)
            {
                Debug.DrawLine(headPositionPrevious[i], headPositionPrevious[i] + new Vector2(0, 0.1f), Color.yellow);
            }

        }



        private void UpdatePreviousPositions()
        {
            beforeStartOfArray = startOfArray - 1;
            if (beforeStartOfArray == -1)
            {
                beforeStartOfArray = bodySegments.Length * 10 - 1;
            }


            //Remove this code post testing
            if (distanceBetweenSegments <= 0)
            {
                distanceBetweenSegments = 0.01f;
                Debug.Log("don't");
            }



            distanceMoved += Vector3.Distance(transform.position, previousFramePosition);
            while (distanceMoved >= distanceBetweenSegments)
            {
                distanceMoved -= distanceBetweenSegments;

                headPositionPrevious[startOfArray] = transform.position;
                startOfArray += 1;

                if (startOfArray == bodySegments.Length * 10)
                {
                    startOfArray = 0;
                }
            }
        }

        private void ShiftingTheList()
        {
            //Remove list removes specific values not first element, otherwise useful
            //headPositionPrevious.Remove(!null);
        }

        //not working???
        private void WASDTest()
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(1,0,0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-1,0,0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 1, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, -1, 0);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("COLLIDING");
            if (collision.gameObject == leftWall)
            {
                //Should use magnitude but angry ):<
                centipedeHorizontalAngle *= -1;
            }
            if (collision.gameObject == rightWall)
            {
                centipedeHorizontalAngle *= -1;
            }
            if (collision.gameObject == roof)
            {
                Debug.Log("ROOF");
                fall = true;
            }
            if (collision.gameObject == floor)
            {
                fall = false;
            }
        }

        private void Fall()
        {
            if (fall)
            {
                //Debug.Log("FALL");
                //transform.position += Vector3.down * centipedeSpeedFall + new Vector3(0, bodySegments.Length, 0) * centipedeSpeedFall;
                transform.position += Vector3.down * centipedeSpeedFall;
            }
            else
            {
                //transform.position += Vector3.up * centipedeSpeedRise + new Vector3(0, bodySegments.Length, 0) * centipedeSpeedRise;
                transform.position += Vector3.up * centipedeSpeedRise;
            }
        }

        private void HorizontalMove()
        {
            transform.position += Vector3.right * centipedeSpeedHorizontal * centipedeHorizontalAngle;
        }

        

        public void DeadSegment(GameObject deadPart)
        {
            for (int deadPartArrayRef = 0; deadPartArrayRef < numberOfbodySegments; deadPartArrayRef++)
            {
                if (bodySegments[deadPartArrayRef] == deadPart)
                {
                    
                    int countToEndOfRange = startOfArray + 10*deadPartArrayRef;
                    /*
                    if (countToEndOfRange >= bodySegments.Length)
                    {
                        countToEndOfRange -= bodySegments.Length;
                    }
                    */

                    List<Vector2> FrontOfWormList = headPositionPrevious.GetRange(startOfArray, countToEndOfRange);
                    List<Vector2> BackOfWormList = headPositionPrevious.GetRange(deadPartArrayRef, bodySegments.Length - countToEndOfRange);

                    newHead = bodySegments[deadPartArrayRef + 1].AddComponent<SegmentBody>();

                    newHead.headPositionPrevious = BackOfWormList;
                    newHead.fall = fall;
                    newHead.attachedHead = deadPart;
                    newHead.floor = floor;
                    newHead.roof = roof;
                    newHead.leftWall = leftWall;
                    newHead.floor = floor;
                    newHead.centipedeHorizontalAngle = UnityEngine.Random.Range(-1f, 1f);

                    int Current = 0;
                    for (int i = 0 + deadPartArrayRef; i <= bodySegments.Length; i++)
                    {
                        
                        newHead.bodySegments[Current] = bodySegments[i];
                        Current += 1;
                    }
                    
                    //rb.mass = 10;

                    headPositionPrevious = FrontOfWormList;
                }
            }

            
        }


    }
}