using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]
    public float health = 100f;
    public float damage = 10f;
    public float movementSpeed = 20f;
    public float jumpForce = 5f;
    protected bool CheckDeath()
    {
        return health <- 0;
    }

}
