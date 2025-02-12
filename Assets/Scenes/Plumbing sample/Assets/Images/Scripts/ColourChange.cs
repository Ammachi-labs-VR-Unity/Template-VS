using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("faucet"))
        {

        }
    }
}
