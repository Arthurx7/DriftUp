using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOff : MonoBehaviour
{
    private float originalMass;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();

            if (carRigidbody != null)
            {
                originalMass = carRigidbody.mass;
                StartCoroutine(ApplyPowerUpEffects(carRigidbody));
                GetComponent<Collider>().enabled = false; 
                GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private IEnumerator ApplyPowerUpEffects(Rigidbody carRigidbody)
    {
        carRigidbody.mass = 100f;
        //carRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        yield return new WaitForSeconds(1.5f);

        carRigidbody.useGravity = false;

        yield return new WaitForSeconds(10f);

        //carRigidbody.constraints = RigidbodyConstraints.None;
        carRigidbody.useGravity = true;
        carRigidbody.mass = originalMass;

    }
}
