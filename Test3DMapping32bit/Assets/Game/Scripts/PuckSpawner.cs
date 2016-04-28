using UnityEngine;
using System.Collections;

public class PuckSpawner : MonoBehaviour {

    public Transform Origin;
    public float FadeInTime;
    public SpawnPointsReference SpawnPoints;
    public Transform World;
    private Logic _logic;
    private Color _colorOpaque;
    private Color _colorTransparent;
    private Renderer _puckRenderer;
    private Rigidbody _puckRigidbody;
    private bool _fadingIn;
    private float _fadeTimer;



    void Start () {
        _logic = transform.parent.GetComponent<Logic>();

    }
	
	void Update () {
	    //if (_fadingIn)
     //   {
     //       _puckRenderer.material.color = Color.Lerp(_colorTransparent, _colorOpaque, _fadeTimer);
     //       _fadeTimer += Time.deltaTime / FadeInTime;
     //       if (_puckRenderer.material.color.a >= _colorOpaque.a)
     //       {
     //           _fadingIn = false;
     //           _puckRigidbody.detectCollisions = true;
     //       }
     //   }
	}

    public void SpawnPuck()
    {
        var puck = PhotonNetwork.Instantiate("Puck", SpawnPoints.PuckSpawn.position, SpawnPoints.PuckSpawn.rotation, 0).transform.parent = World;
        //_puckRenderer = puck.GetComponent<Renderer>();
        //_colorOpaque = _puckRenderer.material.color;
        //_colorTransparent = new Color(_colorOpaque.r, _colorOpaque.g, _colorOpaque.b, 0.0f);
        //_puckRenderer.material.color = _colorTransparent;
        //_fadeTimer = 0;
        //_fadingIn = true;
        //_puckRigidbody = puck.GetComponent<Rigidbody>();
        //_puckRigidbody.detectCollisions = false;
    }
}
