using UnityEngine;
using Photon.Pun;
using TMPro;
/// <summary>
/// this might be one of the most simple scripts
/// in the code.
/// </summary>
public class NamingSystem : MonoBehaviourPunCallbacks
{
    [Header("Refrences")]
    public TextMeshPro username;

    [PunRPC]
    public void sendUsername()
    {
        username.text = InterSceneDataKeeper.Instance.playerName;
    }

}
