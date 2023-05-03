using ArcadeAnarchy;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

//key press to peek DONE
//different key press to hide DONE
//swap out peeking and hiding sprites with each other per respective key press DONE

//ARCADE MACHINE button press(es) to do same as above
//key press to collect Intel, and only when player is peeking

public class HSPlayerControls : MonoBehaviour
{
    //public Sprite playerPeek; //variable to place the peeking char sprite. DEPRECTED. Used when I didn't have animations set up
    //public Sprite playerHide; //variable to place the hiding char sprite. DEPRECTED. Used when I didn't have animations set up

    public GameObject intelSpawner1; //define parent(s) of intel that spawns in, so that we can trigger more spawns
    //public GameObject intelSpawner2;
    //public GameObject intelSpawner3;

    public GameObject Spawns; //spawn point parent object
    public GameObject ingameScreen; //ingame ui object(s)

    public float timeTillGameOver = 5f; //time to wait before game over scene triggers, allows for additional animations, effects, etc.

    public GameObject Countdown; //the mission timer

    public AudioSource audioIfCaught;
    public bool alreadyPlayed = false;

    public AudioSource audioIfPeeking;
    public AudioSource audioIfHiding;

    public GameObject missionFailScr;
    public GameObject ingameScr;

    private bool isDead = false;

    public Animator playerAnim; //reference to player animator
    public bool isPeeking = false; //determines whether a player can get caught and/or collect intel

    void Awake()
    {
        HSIntelScore.playerIntel = 0; //resets intel score to 0 each new game
    }

    void Update()
    {
        GameObject guardFacing;
        guardFacing = GameObject.FindWithTag("GuardFront"); //search for any guards facing the player

        //bool playerIsPeeking = gameObject.GetComponent<SpriteRenderer>().sprite == playerPeek; //playerPeek Sprite must be active

        GameObject intelIsHere;
        intelIsHere = GameObject.FindWithTag("Intel"); //search Intel present in the scene

        if (Input.GetKeyDown(KeyCode.W)) //if W is pressed...
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = playerPeek; //swap to peeking player sprite.
            playerAnim.SetBool("isPeekingAnim", true);
            isPeeking = true;
            audioIfPeeking.Play();
            //Debug.Log("up/peek was pressed");
        }
        if (Input.GetKeyDown(KeyCode.S)) //if S is pressed...
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = playerHide; //swap to hiding player sprite
            playerAnim.SetBool("isPeekingAnim", false);
            isPeeking = false;
            audioIfHiding.Play();
            //Debug.Log("down/hide was pressed");
        }
        if (guardFacing == true && /*playerIsPeeking == true*/ isPeeking == true) //if there are guards facing a peeking player...
        {
            Countdown.GetComponent<HSCountdown>().timerIsRunning = false; //stops the mission timer
            PlayAudio();
            missionFailScr.SetActive(true); //show the "mission complete" UI
            ingameScr.GetComponent<AudioSource>().pitch = 0.5f;
            Time.timeScale = 0; //effectively pauses the game, minus audio
            StartCoroutine(GameOverScreen()); //basically preventing the game over screen from appearing for x seconds
            this.enabled = false; //disables this update function. Resets on new game because it's reloading the scene
            //Debug.Log("Game over screen triggered from " + name);


            //EventManager.instance.TriggerGameOver(); //triggers universal game over screen and menu
            //Debug.Log("caught by guard! Snake? Snaaaaaake!");

            //Spawns.SetActive(false); //disables spawned objects on screen
            //ingameScreen.SetActive(false); //disable ingame ui
            //Destroy(gameObject); //TEST. "kill" player for now, if seen
        }
        if (Input.GetKeyDown(KeyCode.Space) && /*playerIsPeeking == true*/ isPeeking == true && intelIsHere == true) //if the player presses Space while peeking...
        {
            intelIsHere.SetActive(false); //disable Intel sprite
            //Debug.Log("intel collected!");

            intelSpawner1.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            //intelSpawner2.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
            //intelSpawner3.GetComponent<HSIntelSpawn>().intelCount--; //reduce the number of intel reported by the IntelSpawn script
        }
    }

    void PlayAudio()
    {
        if (!alreadyPlayed)
        {
            audioIfCaught.Play();
            alreadyPlayed = true;
        }
    }

    IEnumerator GameOverScreen()
    {
		TicketTier earned = TicketTier.None; //giving 0 tickets to player if they're detected
        if (!isDead)
        {
            isDead = true;
		    yield return new WaitForSecondsRealtime(timeTillGameOver); //overrides timescale changes
		    EventManager.instance.TriggerGameOver(earned); //triggers universal game over screen and menu
            Debug.Log("Y O U D I E D");
        }
	}
}