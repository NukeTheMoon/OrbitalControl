using UnityEngine;
using System.Collections;

public class AttractInputWhenWithinBounds : MonoBehaviour {

    public GameObject Input;
    public GameObject TableSurface;
    private float _lampHeight = 1.0f;
    private float _tableWidth = 1.3f;
    private float _tableLength = 2.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!(AboveLampHeight() ||
            LeftOfTableBounds() || RightOfTableBounds() ||
            BehindTableBounds() || InFrontOfTableBounds()))
        {
            if (BelowStandardHeight())
            {
                Input.transform.position = new Vector3(transform.position.x, Input.transform.position.y, transform.position.z);
            }
            else
            { 
                Input.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

    }

    private bool BehindTableBounds()
    {
        return transform.position.z < -_tableLength / 2;
    }

    private bool InFrontOfTableBounds()
    {
        return transform.position.z > _tableLength / 2;
    }

    private bool LeftOfTableBounds()
    {
        return transform.position.x < -_tableWidth / 2;
    }

    private bool RightOfTableBounds()
    {
        return transform.position.x > _tableWidth / 2;
    }

    private bool AboveLampHeight()
    {
        return transform.position.y > TableSurface.transform.position.y + _lampHeight;
    }

    private bool BelowStandardHeight()
    {
        return transform.position.y < TableSurface.transform.position.y + 0.05f;
    }
}
