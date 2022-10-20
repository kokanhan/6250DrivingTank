using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Door_O : MonoBehaviour
{
    [Header("Door Interaction Part")]
    public GameObject door_closed;
    public GameObject door_opened;
    public GameObject openText;

    [Header("Sound Effect")]
    public AudioSource open, close;

    [Header("Door Status")]
    public bool opened;
    public float waitingTime = 6.0f;

    //void Start()
    //{
    //    door_closed.SetActive(true);
    //    door_opened.SetActive(false);
    //}

    // OnTriggerStay: This message is sent to the trigger and the collider that touches the trigger.
    // Note that trigger events are only sent if one of the colliders also has a rigidbody attached. 
    // Why use it?: OnTriggerStay() method will be called each frame as long as an object will be inside a trigger.
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera")|| other.CompareTag("Player"))
        {
            Debug.Log("close the door!");
            //if (opened == false)
            //{
            //    openText.SetActive(true);
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {
            //        Debug.Log("pressed");
            //        door_closed.SetActive(false);
            //        door_opened.SetActive(true);
            //        //This is for auto closing the door 
            //        //StartCoroutine(repeat());
            //        opened = true;
            //    }
            //}

            //comment below out when you use for opened door, otherwise, comment the above out
            
                    openText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("You pressed close the door");
                        door_closed.SetActive(true);
                        door_opened.SetActive(false);
                        //opened = false;
                    }
                
        }
    }

 

    //This is for auto closing the door 
    IEnumerator repeat()
    {
        yield return new WaitForSeconds(waitingTime);
        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            openText.SetActive(false);
        }
    }
}
