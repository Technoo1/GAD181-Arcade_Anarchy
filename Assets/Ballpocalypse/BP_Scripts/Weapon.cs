using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{


    public Transform firePoint;
    public Transform crouchFirePoint;
    public Transform upFirePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    

    private void Update()
    {

        if ((Input.GetButton("Crouch") == true && Input.GetButtonDown("Fire1")))
        {
            CrouchShot();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetBool("IsShooting", true);
            
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }

        if ((Input.GetButton("Crouch") == true && Input.GetButtonDown("Fire2")))
        {
            CrouchShot();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ShootUp();
            animator.SetBool("IsShootingUp", true);

        }
        else
        {
            animator.SetBool("IsShootingUp", false);
        }



        void CrouchShot()
        {
            Instantiate(bulletPrefab, crouchFirePoint.position, crouchFirePoint.rotation);
        }


    }
      void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         

      } 

    void ShootUp()
    {
        Instantiate(bulletPrefab, upFirePoint.position, upFirePoint.rotation);
    }

   
}
