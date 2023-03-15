<<<<<<< HEAD:Assets/CentipedeBreakout/CentipedeController.cs
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace CentipedeBreakout
{
    public class CentipedeController : MonoBehaviour
    {
        private Collider2D collider;
        private Rigidbody2D rb;

        private bool fall;
        private Vector3 horizontal = Vector2.right;
        private float centipedeHorizontalAngle = 0.1f;
        private Vector2[] previousPosition;
        private float distanceMoved;
        private Vector2 previousFramePosition;
        
        public float centipedeSpeedFall;
        public float centipedeSpeedRise;
        public float centipedeSpeedHorizontal;
        

        public GameObject leftWall;
        public GameObject roof;
        public GameObject rightWall;
        public GameObject floor;
        public GameObject player;
        public GameObject hit;
        public GameObject[] centipedeSegments;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 1; i < 100; i++)
            {
                previousPosition[i] = new Vector2(0,2);
            }


            rb = GetComponent<Rigidbody2D>();
            //Debug.Log("Active");
        }

        // Update is called once per frame
        void Update()
        {
            Fall();
            HorizontalMove();

            distanceMoved += Mathf.Sqrt(Mathf.Pow(previousFramePosition.x - transform.position.x, 2) - Mathf.Pow(previousFramePosition.y - transform.position.x, 2));
            previousFramePosition = transform.position;
            //Debug.Log("Active");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
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

        private float UpdatePositions(float distanceMoved)
        {
            
            while (distanceMoved > 0.1)
            {
                
                distanceMoved -= 0.1f;
            }
            return 1f;
        }

        private void Fall()
        {
            if (fall)
            {
                Debug.Log("FALL");
                transform.position += Vector3.down * centipedeSpeedFall + new Vector3(centipedeSegments.Length, 0, 0) * centipedeSpeedFall;
            }
            else
            {
                transform.position += Vector3.up * centipedeSpeedRise + new Vector3(centipedeSegments.Length, 0, 0) * centipedeSpeedRise;
            }
        }

        private void HorizontalMove()
        {
            transform.position += Vector3.right * centipedeSpeedHorizontal * centipedeHorizontalAngle;
        }

    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public GameObject attachedHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject + "Object clicked");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> MaxsBranch:Assets/CentipedeBreakout/Centipede Breakout testing/Segment.cs
