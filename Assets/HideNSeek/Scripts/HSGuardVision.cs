using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

//DONE guard performs a check after x seconds DONE
//DONE check is 50% chance to swap to another sprite DONE
//DONE if check is successful, swap to alerted/turning guard sprite (this will be an otherwise identical sprite with an added visual cue i.e. exclamation point hanging overhead)
//DONE wait x seconds before swapping again to a front-facing guard sprite
//DONE wait x seconds before swapping back to original sprite
//DONE start first check again
//DONE if check is UNsuccessful, do nothing
//DONE wait x seconds before checking again
//DONE iterate additional check to move left or right, if initial front swap fails

public class HSGuardVision : MonoBehaviour
{
    public int guardTurnChance; //must exceed this value, a percentage chance, a good example is 50% or 33%
    public int guardTurnCheck; //the result of the random range check
    public int guardMoveRChance; //value to check against, change in inspector
    public int guardMoveRCheck; //a random value generated, do not change, can be made private
    public int guardMoveLChance; //value to check against, change in inspector
    public int guardMoveLCheck; //a random value generated, do not change, can be made private

    public float waitForCheck = 1f; //guard starts to check after x second/s
    public float waitTillTurn = 1f; //guard waits to fully turn to face player
    public float waitBeforeSwapBack = 2f; //wait x seconds before swapping back to original sprite
    public float waitForLoop = 3f; //wait x seconds before looping

    //public Sprite guardTurn; //sprite of all turning guards
    //public Sprite guardTurnL; //sprite of all turning guards that face left
    //public Sprite guardFront; //sprite of all guards facing forward
    //public Sprite guardProfile; //sprite of all guards looking away, default state
    //public Sprite guardProfileL; ////sprite of all guards looking away to DA LEFT
    //public Sprite guardAlert; //sprite of all guards detecting the player

    public AudioSource guardTurningAudio;

    public bool moveRight = false;
    public bool moveLeft = false;

    public Animator guardAnim;

    void Start()
    {
        StartCoroutine(StartPatrol());
    }

    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(waitForCheck); //waits before executing further
        {
            for (int i = 0; i < 100000000; i++) //loops the coroutine for a gajillion amount of seconds
            {
                moveRight = false;
                moveLeft = false;
                guardAnim.SetBool("isMovingRightAnim", false);
                guardAnim.SetBool("isMovingLeftAnim", false);
                guardAnim.SetBool("isFacing", false);
                guardAnim.SetBool("isTurning", false);

                yield return new WaitForSeconds(1f);

                guardTurnCheck = Random.Range(0, 99); //random number between 1 and 100
                if (guardTurnCheck > guardTurnChance) //if the result is greater than the specified value...
                {
                    //this.gameObject.GetComponent<SpriteRenderer>().sprite = guardTurn; //swap to turning sprite
                    guardAnim.SetBool("isTurning", true);
                    guardTurningAudio.Play();
                    //Debug.Log("guard is turning!");
                    yield return new WaitForSeconds(waitTillTurn); //wait before swapping again
                    {
                        //this.gameObject.GetComponent<SpriteRenderer>().sprite = guardFront; //swap to front-facing sprite
                        guardAnim.SetBool("isFacing", true);
                        guardAnim.SetBool("isTurning", false);
                        transform.tag = "GuardFront";
                        //Debug.Log("guard is facing you!!");
                        yield return new WaitForSeconds(waitBeforeSwapBack); //wait before swapping again
                        {
                            //this.gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile; //swap to profile sprite
                            guardAnim.SetBool("isFacing", false);
                            transform.tag = "GuardProfile";
                            //Debug.Log("guard has turned away");
                            yield return new WaitForSeconds(waitForLoop); //wait before looping
                        }
                    }
                    //if (CompareTag("guardProfile"))
                    //{
                    //    gameObject.GetComponent<SpriteRenderer>().sprite = guardTurn; //swap to turning sprite
                    //    Debug.Log("guard is turning from the right!");
                    //    yield return new WaitForSeconds(waitTillTurn); //wait before swapping again
                    //    {
                    //        gameObject.GetComponent<SpriteRenderer>().sprite = guardFront; //swap to front-facing sprite
                    //        transform.tag = "GuardFront";
                    //        //Debug.Log("guard is facing you!!");
                    //        yield return new WaitForSeconds(waitBeforeSwapBack); //wait before swapping again
                    //        {
                    //            gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile; //swap to profile sprite
                    //            transform.tag = "GuardProfile";
                    //            //Debug.Log("guard has turned away");
                    //            yield return new WaitForSeconds(waitForLoop); //wait before looping
                    //        }
                    //    }
                    //}
                    //else if (CompareTag("guardProfileL"))
                    //{
                    //    gameObject.GetComponent<SpriteRenderer>().sprite = guardTurnL; //swap to turning sprite facing left
                    //    Debug.Log("guard is turning from the left!");
                    //    yield return new WaitForSeconds(waitTillTurn); //wait before swapping again
                    //    {
                    //        gameObject.GetComponent<SpriteRenderer>().sprite = guardFront; //swap to front-facing sprite
                    //        transform.tag = "GuardFront";
                    //        //Debug.Log("guard is facing you!!");
                    //        yield return new WaitForSeconds(waitBeforeSwapBack); //wait before swapping again
                    //        {
                    //            gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile; //swap to profile sprite
                    //            transform.tag = "GuardProfile";
                    //            //Debug.Log("guard has turned away");
                    //            yield return new WaitForSeconds(waitForLoop); //wait before looping
                    //        }
                    //    }
                    //}
                }
                else
                    {
                    guardMoveRCheck = Random.Range(0, 99);
                    guardMoveLCheck = Random.Range(0, 99);
                    if (guardMoveRCheck > guardMoveRChance)
                    {
                        //gameObject.GetComponent<SpriteRenderer>().sprite = guardProfile; //swap to profile sprite (right as default)
                        transform.tag = "GuardProfile";
                        ////Debug.Log("guard is moving right!");
                        moveRight = true;
                        yield return new WaitForSeconds(waitForLoop);
                    }
                    else if (guardMoveLCheck > guardMoveLChance)
                    {
                        //gameObject.GetComponent<SpriteRenderer>().sprite = guardProfileL; //swap to left-facing profile sprite
                        transform.tag = "GuardProfileL";
                        ////Debug.Log("guard is moving left!");
                        moveLeft = true;
                        yield return new WaitForSeconds(waitForLoop);
                    }
                    else
                    {
                        //Debug.Log("guard did nothing...");
                        yield return new WaitForSeconds(waitForLoop); //wait before looping
                    }
                }
                //else
                //{
                //    //Debug.Log("guard did nothing...");
                //    yield return new WaitForSeconds(5f); //wait 5 seconds before looping
                //}
            }
            yield return null;
        }
    }

    void Update()
    {
        //if a moveleft or moveright boolean is true in coroutine, transform the position of the guard smoothly until guard checks to move again
        if (moveRight)
        {
            guardAnim.SetBool("isMovingRightAnim", true);
            transform.position += 0.5f * Time.deltaTime * Vector3.right;
        }
        if (moveLeft)
        {
            guardAnim.SetBool("isMovingLeftAnim", true);
            transform.position += 0.5f * Time.deltaTime * Vector3.left;
        }
    }
}