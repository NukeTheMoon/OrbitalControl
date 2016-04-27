using Photon;
using UnityEngine;

public class Player1Goal : PunBehaviour {

    public Logic Logic;

    public void OnCollisionEnter(Collision collision)
    {
        PhotonNetwork.Destroy(collision.gameObject);
        ++Score.Player2Score;
        Logic.PuckSpawner.SpawnPuck();
    }
}
