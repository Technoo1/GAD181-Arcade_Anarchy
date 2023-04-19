using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShooting : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    public Transform bulletTransform;
    public Transform crouchFirePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public AudioClip fireBullet;
    public AudioSource bulletSource;



    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
              
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bulletPrefab, bulletTransform.position, Quaternion.identity);
            animator.SetBool("IsShooting", true);
            bulletSource.PlayOneShot(fireBullet);
        }
        else
        {
            animator.SetBool("IsShooting", false);
            
        }
    }

    private void InstantiateAudio(AudioClip clip)
    {
        bulletSource = gameObject.AddComponent<AudioSource>();
        bulletSource.clip = clip;
    }
}
