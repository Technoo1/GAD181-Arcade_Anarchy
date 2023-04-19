using ArcadeAnarchy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienManager : MonoBehaviour
{
    public static AlienManager instance;

    public AnimationHandler[] prefabs;
    public int rows = 3;
    public int columns = 9;
    public int deadAliens;
    public ScreenShake cameraShake;
    // public AnimationCurve speed;

    public int amountkilled {get; private set;}
    public int totalAliens => this.rows * this.columns;
    // public float percentKilled => (float)this.amountkilled / (float)this.totalAliens;


    private Vector3 _direction = Vector2.right;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<ScreenShake>();
    }
    private void Awake() 
    {
        instance = this;

        for(int row = 0; row < this.rows; row++) // A for loop to instantiate the aliens
        {
            // Code to offset/center the alien swarm on screen
            float width = 2.2f * (this.columns - 1);
            float height = -1.7f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);            
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            
            for(int col = 0; col < this.columns; col++) // A for loop to instantiate Aliens 
            {
                AnimationHandler Aliens = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                Aliens.transform.localPosition = position;
            }
        }
    }

    private void Update() 
    {
        //this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform Aliens in this.transform)
        {
            if(!Aliens.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && Aliens.position.x == rightEdge.x - 1.0f)
            {
                AdvanceRow();         
            } 
            else if (_direction == Vector3.left && Aliens.position.x == leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
            
            if (_direction == Vector3.right && Aliens.position.x > rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && Aliens.position.x > leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
        }
        if (deadAliens >= totalAliens)
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
    }

    private void alienKilled()
    {
        this.amountkilled ++;
        //StartCoroutine(cameraShake.Shake(.15f, .4f)); // Script to cause Camera shake once alien is killed.
        cameraShake.ShakeScreen();
        Debug.Log("Screenshake has been called.");
    }
}
