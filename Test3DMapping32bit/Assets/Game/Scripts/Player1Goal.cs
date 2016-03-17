using UnityEngine;

public class Player1Goal : MonoBehaviour {

    public Logic Logic;

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        ++Score.Player2Score;
        Logic.PuckSpawner.SpawnPuck();
    }
}
