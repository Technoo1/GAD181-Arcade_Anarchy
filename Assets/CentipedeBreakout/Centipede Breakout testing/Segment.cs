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
        private Renderer ren;

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

        public void Death()
        {
            attachedHead.GetComponent<SegmentBody>().DeadSegment(gameObject);

            Debug.Log("Murder");
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
                        Debug.Log("HEY LISTEN");
                        break;
                    }
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}