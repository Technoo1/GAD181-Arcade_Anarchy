using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBody : Segment
{
    //tracks how far apart each body segment is and the values where it can be.
    private float distanceMoved;
    public Vector2[] headPositionPrevious;
    private Vector3 previousFramePosition;


    //allows you to edit how long a centipede is, on start.
    public int numberOfbodySegments;
    public GameObject bodyPrefab;
    public float distanceBetweenSegments;

    private GameObject[] bodySegments;


    //A counter for where the most recently updated value is, ++ is oldest, -- is newest
    private int startOfArray = 1;
    private int beforeStartOfArray;
    


    // Start is called before the first frame update
    void Start()
    {
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

        for (int i = 0; i == bodySegments.Length * 10 - 1; i++)
        {
            headPositionPrevious[i] = new Vector2(1000,0);
        }

        headPositionPrevious = new Vector2[bodySegments.Length * 10];

    }

    // Update is called once per frame
    void Update()
    {
        WASDTest();

        
        UpdatePreviousPositions();
        DebugVisual();


        int i = 1;
        foreach (var item in bodySegments)
        {
            int x = 0;
            if (startOfArray + i*10 > bodySegments.Length * 10 - 1)
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


    //Known issue, distance updates constantly meaning any amount of movement creates new co-ordinates given enough time
    //e.g if the centipede is slow enough it will congeal together.
    private void UpdatePreviousPositions()
    {
        beforeStartOfArray = startOfArray -1;
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

    //not working???
    private void WASDTest()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0.1f,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.1f, 0, 0);
        }
    }

    
}