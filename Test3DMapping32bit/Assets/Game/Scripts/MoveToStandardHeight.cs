using UnityEngine;
using System.Collections;

public class MoveToStandardHeight : MonoBehaviour {

    public Transform StandardHeight;
    
    private MeshFilter _mesh;
	
    void Start()
    {
        _mesh = GetComponent<MeshFilter>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, StandardHeight.position.y, 0);
        }
    }
}
