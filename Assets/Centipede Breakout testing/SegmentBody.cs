using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBody : MonoBehaviour
{
    private float distanceMoved;
    public Vector2[] headPositionPrevious = new Vector2[100];
    private Vector3 positionPreviousFrame;
    public GameObject[] bodySegments = new GameObject[10];

    //A counter for where the most recently updated value is, ++ is oldest, -- is newest
    private int startOfArray = 1;
    private int beforeStartOfArray;

    // Start is called before the first frame update
    void Start()
    {
        headPositionPrevious = new Vector2[100];

        positionPreviousFrame = new Vector3(0, 2, 0);
        headPositionPrevious[0] = new Vector2(0, 2);

        //defines array length
        for(int i = 0; i == 99; i++)
        {
            headPositionPrevious[i] = Vector2.zero;
        }
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
            if (startOfArray + i*10 > 99)
            {
                x = startOfArray + i * 10 - 100;
            }
            else
            {
                x = startOfArray + i * 10;
            }
            item.transform.position = headPositionPrevious[x];
            i++;
        }


    }

    private void DebugVisual()
    {
        
        for (int i = 0; i < 100; i++)
        {
            Debug.DrawLine(headPositionPrevious[i], headPositionPrevious[i] + new Vector2(0, 0.1f), Color.yellow);
        }
        
    }

    private void UpdatePreviousPositions()
    {
        beforeStartOfArray = startOfArray -1;
        if (beforeStartOfArray == -1)
        {
            beforeStartOfArray = 99; 
        }

     
        distanceMoved += Vector3.Distance(transform.position, headPositionPrevious[beforeStartOfArray]);
        while (distanceMoved >= 0.1)
        {
            distanceMoved -= 0.1f;
            
            headPositionPrevious[startOfArray] = transform.position; 
            startOfArray += 1;

            if (startOfArray == 100)
            {
                startOfArray = 0;
            }
        }


        

    }

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