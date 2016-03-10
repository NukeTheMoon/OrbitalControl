using UnityEngine;

public class Player2Goal : MonoBehaviour {

    public Logic Logic;

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        ++Score.Player1Score;
        Logic.PuckSpawner.SpawnPuck();
    }
}
