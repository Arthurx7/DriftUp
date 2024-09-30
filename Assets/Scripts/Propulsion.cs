using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsion : MonoBehaviour
{
    public float propulsionForce = 10000f; 
    public float duration = 5f;
    public GameObject children;    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Car"))
        {
           
            PrometeoCarController carController = other.GetComponent<PrometeoCarController>();

            ParticleSystem magicFire0 = other.transform.Find("Magic fire 0")?.GetComponent<ParticleSystem>();
            ParticleSystem magicFire1 = other.transform.Find("Magic fire 1")?.GetComponent<ParticleSystem>();

            if (carController != null && magicFire0 != null && magicFire1 != null)
            {
                StartCoroutine(ApplyPowerup(other.gameObject, carController, magicFire0, magicFire1));
            }
            else
            {
                Debug.LogWarning("El carro no tiene todos los componentes necesarios.");
            }
            children.SetActive(false);
        }
    }

    private IEnumerator ApplyPowerup(GameObject car, PrometeoCarController carController, ParticleSystem magicFire0, ParticleSystem magicFire1)
    {
        
        carController.enabled = false;

        magicFire0.Play();
        magicFire1.Play();

        Rigidbody carRigidbody = car.GetComponent<Rigidbody>();
        if (carRigidbody != null)
        {
            carRigidbody.AddForce(car.transform.forward * propulsionForce, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(duration);

        carController.enabled = true;

        magicFire0.Stop();
        magicFire1.Stop();

    }
}
