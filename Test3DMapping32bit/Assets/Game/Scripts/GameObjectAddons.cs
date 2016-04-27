using UnityEngine;


public static class GameObjectAddons
{
    public static GameObject GetChildGameObject(this GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    public static void FollowTarget(this GameObject from, Transform target, float distanceToStop, float speed)
    {
        var rigidbody = from.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            var direction = Vector3.zero;
            while (Vector3.Distance(from.transform.position, target.position) > distanceToStop)
            {
                direction = target.position - from.transform.position;
                rigidbody.AddRelativeForce(direction.normalized * speed, ForceMode.Force);
            }
        }
    }
}
