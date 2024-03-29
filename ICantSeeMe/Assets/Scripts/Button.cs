using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Button : Trigger
{
    private bool _done;
    public string Sound;

    private void Awake()
    {
        _done = false;
    }

    [PunRPC]
    public override void trigger()
    {
        AudioManager.instance.RpcPlaySound(Sound);
        foreach (GameObject t in toActivate)
            t.GetComponent<Triggerable>().activate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Tool")
            return;
        //     Debug.Log("collisione con bottone");
        if (!_done)
        {
            photonView.RPC("trigger", RpcTarget.All, null);
            _done = true;
        }
    }
}
