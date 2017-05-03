using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomy : Enemy
{
    [Header("Boomy")]

    public GameObject onSelfDestruct;
    public SphereCollider explosionSphere;
    public float explosionDelay = 2f;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    protected override void Attack()
    {
        StartCoroutine(StartDestuction(explosionDelay));
    }

    protected override void OnDeath()
    {
        SelfDestruct();
    }

    void SelfDestruct()
    {
        PlayExplosion();
        Explode();
        Destroy(gameObject);
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(onSelfDestruct);
        explosion.transform.position = transform.position;
    }

    void Explode()
    {
        //Check if we hit anything on explode
        Collider[] hits = Physics.OverlapSphere(explosionSphere.transform.position, explosionSphere.radius * explosionSphere.transform.localScale.magnitude);
        //Loop through all the objects that we hit
        for (int i = 0; i < hits.Length; i++)
        {
            Collider hit = hits[i];
            Character character = hit.GetComponent<Character>();
            //Check if we hit a character
            if (character != null)
            {
                character.health -= damage;
            }
        }
        health = 0;
    }

    IEnumerator StartDestuction(float delay)
    {
        anim.SetTrigger("Explode");

        yield return new WaitForSeconds(delay);

        //check if we are sill at target
        if (IsAtTarget())
        {
            // Self Destruct
            SelfDestruct();
        }

        else
        {
            //otherwise
            //reset animation
            anim.SetTrigger("Deactivated");
        }

    }
}
