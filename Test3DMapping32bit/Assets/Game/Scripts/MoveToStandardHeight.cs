using UnityEngine;
using System.Collections;

public class MoveToStandardHeight : MonoBehaviour {

    private Transform _standardHeight;
    
    private MeshFilter _mesh;
	
    void Start()
    {
        _mesh = GetComponent<MeshFilter>();
        _standardHeight = GameObject.FindGameObjectWithTag("StandardHeight").transform;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, _standardHeight.position.y, 0);
        }
    }
}
