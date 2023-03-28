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

        // Start is called before the first frame update
        void Start()
        {

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

        // Update is called once per frame
        void Update()
        {

        }
    }
}