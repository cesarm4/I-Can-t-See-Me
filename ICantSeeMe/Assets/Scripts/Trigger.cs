using Photon.Pun;
using UnityEngine;

public class Trigger : MonoBehaviourPun
{
    public GameObject[] toActivate;

    [PunRPC]
    public virtual void trigger()
    {

    }
}
