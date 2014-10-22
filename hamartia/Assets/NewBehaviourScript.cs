using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public DogController playerChar;
    
    public void OnTriggerEnter(Collider other) {
        if (other == playerChar) {
            playerChar.SendMessage("SetJumpDamage", true);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other == playerChar) {
            playerChar.SendMessage("SetJumpDamage", true);
        }
    }
}
