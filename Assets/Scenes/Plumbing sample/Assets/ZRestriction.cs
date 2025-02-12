using UnityEngine;

public class RestrictZRotation : MonoBehaviour
{
    [SerializeField] private float maxRotationZ = 45f;
    [SerializeField] private float minRotationZ = -45f;

    private Transform localTrans;

    private void Update()
    {
        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minRotationZ, maxRotationZ);

        localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    }
}