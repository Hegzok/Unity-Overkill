using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAmmo : Ammunition
{
    // Update is called once per frame
    void Update()
    {
        FlyStraight();
    }

    private void FlyStraight()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

}
