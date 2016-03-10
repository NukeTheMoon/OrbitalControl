using UnityEngine;

public class DisallowMovementBelowTableSurface : MonoBehaviour
{
    public GameObject TableSurface;


    void Update()
    {
        if (BelowStandardHeight())
        {
            transform.position = new Vector3(transform.position.x, TableSurface.transform.position.y + 0.05f, transform.position.z);
        }
    }

    private bool BelowStandardHeight()
    {
        return transform.position.y < TableSurface.transform.position.y + 0.05f;
    }
}
