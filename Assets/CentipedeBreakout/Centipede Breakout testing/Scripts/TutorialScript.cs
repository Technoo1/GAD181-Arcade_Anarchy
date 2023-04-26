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

    private bool walkActive = false, shootActive = false, swordActive = false;

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

        if (walkActive == false) {
            if (Input.GetKey(KeyCode.D))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[1].SetActive(false);
                walkActive = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[1].SetActive(false);
                walkActive = true;
            }
            if (Input.GetKey(KeyCode.W))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[1].SetActive(false);
                walkActive = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[1].SetActive(false);
                walkActive = true;
            }
        }

        if (shootActive == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[2].SetActive(false);
                shootActive = true;
            }
        }

        if (swordActive == false) {
            if (Input.GetKey(KeyCode.Space))
            {
                CBAudioManager.instance.PlaySound("Bloop");
                TutorialComponents[0].SetActive(false);
                swordActive = true;
            }
        }

    }


}
