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

        public List<GameObject> bodySegments = new List<GameObject>();


        //A counter for where the most recently updated value is, ++ is oldest, -- is newest
        private int startOfArray = 0;
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
        public Rigidbody2D newRigidBody;


        //dumb variables I made cos I was lazy and also didn't have internet
        bool justBorn = true;





        // Start is called before the first frame update
        void Start()
        {
            //rb = gameObject.AddComponent<Rigidbody2D>();

            if (distanceBetweenSegments == 0)
            {
                distanceBetweenSegments = 0.1f;
            }

            //HEHAHHRHERHEAHRI

            //bodySegments = new GameObject[numberOfbodySegments];
            //Creates body parts and tells them what head they are attached to

            if (justBorn) {
                for (int i = 0; i < numberOfbodySegments; i++)
                {

                    

                    bodySegments.Add(Instantiate(bodyPrefab, new Vector3(-3000, 3000, 0), Quaternion.identity));
                    //attached head is called to tell the head if the body part dies
                    //Without it the body part does not know which head it belongs to.
                    bodySegments[i].GetComponent<Segment>().attachedHead = gameObject;
                }
                attachedHead = gameObject;
            }

            if (justBorn) {
                for (int i = 0; i <= bodySegments.Count * 10; i++)
                {
                    headPositionPrevious.Add(new Vector2(1000, 0));
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

            
            //WASDTest();

            Fall();
            HorizontalMove();
            //UpdatePreviousPositions();
            ShiftingTheList();
            
            

            

            

            /*
            int i = 0;
            foreach (var item in bodySegments)
            {
                int x = 0;
                if (startOfArray + i * 10 > bodySegments.Count * 10 - 1)
                {
                    x = startOfArray + i * 10 - bodySegments.Count * 10;
                }
                else
                {
                    x = i * 10;
                }
                item.transform.position = headPositionPrevious[x + 0];
                i++;
            }
            */

            previousFramePosition = transform.position;

            //lol, literally what matt said in class where you can't change a foreach loop ig?
            for (int i = 0; i < bodySegments.Count; i++)
            {
                bodySegments[i].transform.position = headPositionPrevious[i * 10 + 10];
            }

            DebugVisual();
        }

        private void DebugVisual()
        {

            for (int i = 0; i < bodySegments.Count * 10 - 1; i++)
            {
                Debug.DrawLine(headPositionPrevious[i], headPositionPrevious[i] + new Vector2(0, 0.1f), Color.yellow);
            }

        }


        /*
        private void UpdatePreviousPositions()
        {
            beforeStartOfArray = startOfArray - 1;
            if (beforeStartOfArray == -1)
            {
                beforeStartOfArray = bodySegments.Count * 10 - 1;
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



                if (startOfArray == bodySegments.Count * 10)
                {
                    startOfArray = 0;
                }
            }
        }
        */
        private void ShiftingTheList()
        {

            //HIGHLy ANNOYING
            //The code has been modified to accomadate backward lists
            //behind the head is position segment.count and position.count
            //The end of the tail is position 0
            //To fix this the insert function could be used
            //segment.insert(0,element) segment.removeAt(segment.count)
            //I suggest we implement this however first focus on a swing animation






            //Remove list removes specific values not first element, otherwise useful
            //headPositionPrevious.Remove(!null);
            if (distanceBetweenSegments <= 0)
            {
                distanceBetweenSegments = 0.01f;
                Debug.Log("don't");
            }


            //adds to the start then removes the highest value
            //new = 0
            //old = maximum
            distanceMoved += Vector3.Distance(transform.position, previousFramePosition);
            while (distanceMoved >= distanceBetweenSegments)
            {
                distanceMoved -= distanceBetweenSegments;

                

                headPositionPrevious.Insert(0, transform.position);
                headPositionPrevious.RemoveAt(headPositionPrevious.Count -1);
            }
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
            int deadPartArrayRef = bodySegments.IndexOf(deadPart);
            int deadPartPositionRef = deadPartArrayRef * 10 + 10;

            Debug.Log("1");
            //I think when setting position it actually takes 9, 19, 29, 39 rather than multiples of 10
            List<Vector2> FrontOfWormList = headPositionPrevious.GetRange(0, deadPartPositionRef - 0);

            Debug.Log("2");
            //I don't get it
            List<Vector2> BackOfWormList = headPositionPrevious.GetRange(deadPartPositionRef + 0, headPositionPrevious.Count -1 - deadPartPositionRef - 0);


            Debug.Log("3");
            newHead = bodySegments[deadPartArrayRef + 1].AddComponent<SegmentBody>();
            newRigidBody = bodySegments[deadPartArrayRef + 1].AddComponent<Rigidbody2D>();

            bodySegments[deadPartArrayRef + 1].GetComponent<BoxCollider2D>().isTrigger = false;

            newRigidBody.gravityScale = 0;
            newRigidBody.mass = 50;

            Debug.Log("4");
            newHead.headPositionPrevious = BackOfWormList;

            Debug.Log("5");
            newHead.fall = fall;
            newHead.attachedHead = bodySegments[deadPartArrayRef + 1];
            newHead.floor = floor;
            newHead.roof = roof;
            newHead.leftWall = leftWall;
            newHead.rightWall = rightWall;
            newHead.centipedeHorizontalAngle = UnityEngine.Random.Range(-1f, 1f);
            newHead.centipedeSpeedFall = centipedeSpeedFall;
            newHead.centipedeSpeedRise = centipedeSpeedRise;
            newHead.centipedeSpeedHorizontal = centipedeSpeedHorizontal;
            newHead.justBorn = false;


            //attaches body parts to the new head
            for (int i = deadPartArrayRef + 2; i < bodySegments.Count; i++)
            {
                newHead.bodySegments.Insert(0,bodySegments[i]);

            }

            //May need to change once splits 1 rather than 2
            while (bodySegments.Count > deadPartArrayRef)
            {
                bodySegments.RemoveAt(bodySegments.Count - 1);
            }

            //rb.mass = 10;
            //bodySegments.RemoveRange(deadPartArrayRef, (bodySegments.Count) - (deadPartArrayRef));
            //bodySegments.RemoveRange(deadPartArrayRef, (bodySegments.Count) - (deadPartArrayRef));
            headPositionPrevious = FrontOfWormList;
                    
            Debug.Log("Finished");
        }
    }
}