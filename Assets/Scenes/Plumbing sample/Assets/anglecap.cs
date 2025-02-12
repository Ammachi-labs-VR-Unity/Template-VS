using UnityEngine;

public class anglecap : MonoBehaviour
{
    [SerializeField] private Transform parentTransform; 
    [SerializeField] private float maxRotationZ = 45f;
    [SerializeField] private float minRotationZ = -45f;
    [SerializeField] private float resetSpeed = 5f;

    private Vector3 initialPosition;

    public float avgno;

    private Quaternion initialRotation;

    public bool vert = false;
    void Start()
    {
        initialPosition = transform.position;

        initialRotation = transform.rotation;

    }
    void Update()
    {
        if (vert == false)
        {
            Vector3 currentRotation = transform.localEulerAngles;

            float normalizedZRotation = NormalizeAngle(currentRotation.z);

            normalizedZRotation = Mathf.Clamp(normalizedZRotation, minRotationZ, maxRotationZ);

            transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, normalizedZRotation);

            if (Mathf.Abs(NormalizeAngle(transform.eulerAngles.z)) <= avgno)
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * resetSpeed);

                transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * resetSpeed);
            }
        }

        else
        {
            Vector3 currentRotation = transform.localEulerAngles;

            float normalizedZRotation = NormalizeAngle(currentRotation.z);

            normalizedZRotation = Mathf.Clamp(normalizedZRotation, minRotationZ, maxRotationZ);

            transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, normalizedZRotation);

            if (Mathf.Abs(NormalizeAngle(transform.eulerAngles.z)) <= avgno)
            {
                transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * resetSpeed);

                transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * resetSpeed);
            }
        }
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180) angle -= 360;
        return angle;
    }
}