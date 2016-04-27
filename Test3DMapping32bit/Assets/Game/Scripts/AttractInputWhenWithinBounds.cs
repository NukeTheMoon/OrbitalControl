using UnityEngine;
using System.Collections;

public enum PointerColor { Red, Blue }

public class AttractInputWhenWithinBounds : MonoBehaviour {

    public PointerColor ColorOfPointerToAttract;
    private GameObject _tableSurface;
    private GameObject _pointerToAttract;
    private float _lampHeight = 1.0f;
    private float _tableWidth = 1.3f;
    private float _tableLength = 2.5f;

    void Start () {

        switch (ColorOfPointerToAttract) {
            case (PointerColor.Red):
                _pointerToAttract = GameObject.FindGameObjectWithTag("RedPointer");
                break;
            case (PointerColor.Blue):
                _pointerToAttract = GameObject.FindGameObjectWithTag("BluePointer");
                break;
            default:
                break;
        }

        _tableSurface = GameObject.FindGameObjectWithTag("TableSurface");
	}
	
	void Update () {
        if (!(AboveLampHeight() ||
            LeftOfTableBounds() || RightOfTableBounds() ||
            BehindTableBounds() || InFrontOfTableBounds()))
        {
            if (BelowStandardHeight())
            {
                _pointerToAttract.transform.position = new Vector3(transform.position.x, _pointerToAttract.transform.position.y, transform.position.z);
            }
            else
            {
                _pointerToAttract.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
        return transform.position.y > _tableSurface.transform.position.y + _lampHeight;
    }

    private bool BelowStandardHeight()
    {
        return transform.position.y < _tableSurface.transform.position.y + 0.05f;
    }
}
