using CentipedeBreakout;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class TutorialScript : MonoBehaviour
{
    // 0 = sword
    // 1 = walk
    // 2 = shoot
    public GameObject[] TutorialComponents;

    public GameObject moveUI, swordUI, shootUI;

    public GameObject InitialCentipede;

    public GameObject TutorialParent;
    public GameObject GameUI;

    private bool walkActive, shootActive, swordActive;

    void Start()
    {
        GameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (walkActive && shootActive && swordActive)
        {
            GameUI.SetActive(true);
            InitialCentipede.GetComponent<SegmentBody>().OutOfTutorial = true;
            TutorialParent.SetActive(false);
            return;
            //foreach (SpriteRenderer child in moveUI)
            //{
            //newColor = child.color;
            //newColor.a = alpha;
            //child.color = newColor;
            //}
        }

        if (Input.GetKey(KeyCode.D))
        {
            TutorialComponents[1].SetActive(false);
            walkActive = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            TutorialComponents[1].SetActive(false);
            walkActive = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            TutorialComponents[1].SetActive(false);
            walkActive = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            TutorialComponents[1].SetActive(false);
            walkActive = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            TutorialComponents[2].SetActive(false);
            shootActive = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            TutorialComponents[0].SetActive(false);
            swordActive = true;
        }

    }


}
