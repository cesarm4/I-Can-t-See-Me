using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ParchmentTrigger : Trigger
{
    public GameObject parchment;
    public List<UnityEngine.UI.Button> buttons;
    public List<GameObject> toActivateWrongAnswer;
    private bool _isActive = false;
    private GameObject player;
    private PlayerMovement playerMovement;

    [PunRPC]
    public override void trigger()
    {
        _isActive = true;

        //Set panel for player 1
        if (player.name == "Girl")
        {
            parchment.SetActive(true);
            foreach (UnityEngine.UI.Button b in buttons)
                b.interactable = false;
        }
        else
        {
            foreach (UnityEngine.UI.Button b in buttons)
            {
                b.gameObject.SetActive(true);
                b.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Enter inside");
            player = collision.gameObject;
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }
    
    public void CheckAnswer(bool answer)
    {
        parchment.SetActive(false);
        foreach (UnityEngine.UI.Button b in buttons)
            b.gameObject.SetActive(false);
        
        if(answer) {
            foreach (GameObject t in toActivate)
                t.GetComponent<Triggerable>().activate();
        }
        else {
            foreach (GameObject t in toActivateWrongAnswer)
                t.GetComponent<Triggerable>().activate();
        }
    }
}
