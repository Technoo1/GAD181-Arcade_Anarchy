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

        transform.position = Input.mousePosition * 0.1f;
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



        ///transform.position = positionPreviousFrame;

    }

    private void DebugVisual()
    {
        
        for (int i = 0; i < 100; i++)
        {
            Debug.DrawLine(headPositionPrevious[i], headPositionPrevious[i] + new Vector2(0, 1f), Color.yellow);
        }
        
    }

    private void UpdatePreviousPositions()
    {
        beforeStartOfArray = startOfArray -1;
        if (beforeStartOfArray == -1)
        {
            beforeStartOfArray = 99; 
        }

        /*
        //Ensurese that if multiple points are stored in the same position they won't consider distance = 0
        int PreviousMovedPositionCalculator = 1;
        if (transform.position == positionPreviousFrame) {
            
            while (new Vector2(transform.position.x, transform.position.y) == headPositionPrevious[startOfArray - PreviousMovedPositionCalculator])
            {
                PreviousMovedPositionCalculator++;
                // emergency escape
                if (PreviousMovedPositionCalculator == 100)
                {
                    Debug.Log("EMERGENCY ESCAPE WITH SEGMENT BODY LINE, WHILE LOOP");
                    return;
                }
            }
        }
        */

        if (Vector3.Distance(transform.position, headPositionPrevious[beforeStartOfArray/*PreviousMovedPositionCalculator*/]) >= 0.1)
        {
            distanceMoved += Vector3.Distance(transform.position, headPositionPrevious[beforeStartOfArray/*PreviousMovedPositionCalculator*/]);
        }

        
        while (distanceMoved >= 1)
        {
            distanceMoved -= 1;
            
            headPositionPrevious[beforeStartOfArray] = transform.position; 
            startOfArray += 1;

            if (startOfArray == 99)
            {
                startOfArray = 0;
            }
        }


    }
}