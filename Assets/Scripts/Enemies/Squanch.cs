using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squanch : Enemy
{

    public float chargeSpeed = 20f;
    public float chargeDelay = 1f;
    public GameObject onCharge;

    private Rigidbody rigid;
    private Animator anim;


    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    protected override void Attack()
    {
        if(!isAttacking)
        {
            StartCoroutine(Charge(chargeDelay));
        }
    }

    IEnumerator Charge(float delay)
    {
        isAgentActive = false;
        isAttacking = true;
        rigid.AddForce(transform.forward * chargeSpeed, ForceMode.Impulse);
        PlayParticles();
        PlayAnim();

        yield return new WaitForSeconds(delay);

        rigid.velocity = Vector3.zero;
        isAgentActive = true;
        isAttacking = false;
    }

    void PlayParticles()
    {
        GameObject chargeParticles = Instantiate(onCharge);
        chargeParticles.transform.position = transform.position;
        chargeParticles.transform.rotation = transform.rotation;
        chargeParticles.transform.rotation *= Quaternion.AngleAxis(180, Vector3.up);
        chargeParticles.transform.SetParent(transform);
    }

    void PlayAnim()
    {
        //Play charge anim
        anim.SetTrigger("Charge");
    }
}
