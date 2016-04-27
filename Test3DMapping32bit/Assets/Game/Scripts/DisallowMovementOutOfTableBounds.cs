using System;
using UnityEngine;

public class DisallowMovementOutOfTableBounds : MonoBehaviour
{
    private GameObject _tableSurface;
    private float _lampHeight = 1.0f;
    private float _tableWidth = 1.3f;
    private float _tableLength = 2.5f;

    void Start()
    {
        _tableSurface = GameObject.FindGameObjectWithTag("TableSurface");
    }


    void Update()
    {
        if (BelowStandardHeight())
        {
            transform.position = new Vector3(transform.position.x, _tableSurface.transform.position.y + 0.05f, transform.position.z);
        }
        if (AboveLampHeight())
        {
            transform.position = new Vector3(transform.position.x, _tableSurface.transform.position.y + _lampHeight, transform.position.z);
        }
        if (LeftOfTableBounds())
        {
            transform.position = new Vector3(-_tableWidth / 2, transform.position.y, transform.position.z);
        }
        if (RightOfTableBounds())
        {
            transform.position = new Vector3(_tableWidth / 2, transform.position.y, transform.position.z);
        }
        if (InFrontOfTableBounds())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _tableLength / 2);
        }
        if (BehindTableBounds())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -_tableLength / 2);
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
