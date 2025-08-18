using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrephab;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float ejeY;

    private void Start ()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), ejeY);
        PhotonNetwork.Instantiate(playerPrephab.name, randomPosition, Quaternion.identity);
    }
}
