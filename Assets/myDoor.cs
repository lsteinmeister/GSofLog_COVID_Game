using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myDoor : MonoBehaviour
{
    public GameObject Pivot, Door;
    bool DoorOpen = false;
    public float openRotation = 90;

    public void openDoor()
    {
        if(DoorOpen){
            Door.transform.RotateAround (Pivot.transform.position, Vector3.up, -openRotation);
            DoorOpen = false;
        } 
        else{
            Door.transform.RotateAround (Pivot.transform.position, Vector3.up, openRotation);
            DoorOpen = true;
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") openDoor();
    }
}
