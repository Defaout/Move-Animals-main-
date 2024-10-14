using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float radius;
    public float rotationSpeed;

    private void Update()
    {
       
        if (target == null)
        {
            //Debug.LogWarning("Ќе установлена целева€ точка вращени€.");
            return;
        }
        float angle = Time.time * rotationSpeed;
        Vector3 newPosition = new Vector3(Mathf.Sin(angle) * radius, transform.position.y, Mathf.Cos(angle) * radius);
        transform.position = target.position + newPosition;

        transform.LookAt(target);
    }
}