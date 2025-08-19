using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_Text loadingText;
    private string baseText = "Loading";
    private Coroutine loadingCoroutine;
    
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        loadingCoroutine = StartCoroutine(AnimateLoading());
    }

    IEnumerator AnimateLoading()
    {
        int dotCount = 0;

        while (true)
        {
            dotCount = (dotCount + 1) % 4;
            loadingText.text = baseText + new string('.', dotCount);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        if (loadingCoroutine != null)
            StopCoroutine(loadingCoroutine);

        SceneManager.LoadScene("Lobby");
    }
}