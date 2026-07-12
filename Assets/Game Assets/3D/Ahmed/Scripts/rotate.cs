using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationAxis = new Vector3(0,0,1);
    public float maxSpeed = 1500f;
    public float acceleration = 500f;

    private float currentSpeed = 0f;
    public bool isEngineOn = false;

    void Update()
    {
        float targetSpeed = isEngineOn ? maxSpeed : 0f;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        transform.Rotate(rotationAxis * currentSpeed * Time.deltaTime);
    }
}
