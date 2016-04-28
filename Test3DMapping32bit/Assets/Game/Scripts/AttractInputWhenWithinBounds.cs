using UnityEngine;
using System.Collections;

public enum PointerColor { Red, Blue }

public class AttractInputWhenWithinBounds : MonoBehaviour {

    public PointerColor ColorOfPointerToAttract;
    private GameObject _standardHeight;
    private GameObject _pointerToAttract;
    private Quaternion _pointerOriginalRotation;
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

        _pointerOriginalRotation = _pointerToAttract.transform.rotation;
        _standardHeight = GameObject.FindGameObjectWithTag("StandardHeight");
	}
	
	void Update () {
        if (!(AboveLampHeight() ||
            LeftOfTableBounds() || RightOfTableBounds() ||
            BehindTableBounds() || InFrontOfTableBounds()))
        {
            if (AtOrBelowStandardHeight())
            {
                _pointerToAttract.transform.position = new Vector3(transform.position.x, _standardHeight.transform.position.y, transform.position.z);
                _pointerToAttract.transform.rotation = _pointerOriginalRotation;

            }
            else
            {
                _pointerToAttract.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _pointerToAttract.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
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
        return transform.position.y > _standardHeight.transform.position.y + _lampHeight;
    }

    private bool AtOrBelowStandardHeight()
    {
        return transform.position.y <= _standardHeight.transform.position.y + 0.05f;
    }
}
