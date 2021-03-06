﻿using Photon;
using UnityEngine;

public class Player2Goal : PunBehaviour {

    public Logic Logic;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Puck")
        {
            PhotonNetwork.Destroy(collision.gameObject);
            ++Score.Player1Score;
            Logic.PuckSpawner.SpawnPuck();
        }
    }
}
