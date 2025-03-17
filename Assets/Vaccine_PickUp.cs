using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine_PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && other.GetComponent<PlayerBehavior>().HP <5)
        {
            other.GetComponent<PlayerBehavior>().Heal();
            Destroy(gameObject);
        }
    }
}
