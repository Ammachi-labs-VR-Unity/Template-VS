using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothScript : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("faucet"))
        {
            FaucetColour faucet = other.gameObject.GetComponent<FaucetColour>();

            if (faucet != null && !faucet.enabled)
            {
                faucet.enabled = true;
            }
        }

        else if (other.gameObject.CompareTag("hose"))
        {
            FaucetColour faucet = other.gameObject.GetComponent<FaucetColour>();

            if (faucet != null && !faucet.enabled)
            {
                faucet.enabled = true;
            }
        }

        else if (other.gameObject.CompareTag("box"))
        {
            FaucetColour faucet = other.gameObject.GetComponent<FaucetColour>();

            if (faucet != null && !faucet.enabled)
            {
                faucet.enabled = true;
            }
        }

        else if (other.gameObject.CompareTag("basin"))
        {
            FaucetColour faucet = other.gameObject.GetComponent<FaucetColour>();

            if (faucet != null && !faucet.enabled)
            {
                faucet.enabled = true;
            }
        }

        else if (other.gameObject.CompareTag("filter"))
        {
            FaucetColour faucet = other.gameObject.GetComponent<FaucetColour>();

            if (faucet != null && !faucet.enabled)
            {
                faucet.enabled = true;
            }
        }
    }

    private void OnDisable()
    {
        transform.position = originalPosition;
    }
}