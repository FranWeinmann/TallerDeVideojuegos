using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    private void Start() 
    { 
        createInput.onSubmit.AddListener(CreateRoom); 
        joinInput.onSubmit.AddListener(JoinRoom);
    }

    public void CreateRoom (string text)
    {
        PhotonNetwork.CreateRoom(text);
    }
    
    public void JoinRoom (string text)
    {
        PhotonNetwork.JoinRoom(text);
    }

    public override void OnJoinedRoom ()
    {
        PhotonNetwork.LoadLevel("Game");
    }


}
