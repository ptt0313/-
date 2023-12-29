using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<Idamageble> thingsToDamage = new List<Idamageble>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }
    void DealDamage()
    {
        for(int i = 0; i<thingsToDamage.Count; i++)
        {
            thingsToDamage[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Idamageble damagable))
        {
            thingsToDamage.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Idamageble damagable))
        {
            thingsToDamage.Remove(damagable);
        }
    }
}
