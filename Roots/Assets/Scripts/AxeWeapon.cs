using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
    public float timeToAttack;
    public float attackDamage = 1f;
    public int level = 3;

    [SerializeField] ItemData itemData;
    [SerializeField] GameObject axe;
    [SerializeField] float force = 1;

    private PlayerExperience playerExperience;
    private PlayerController playerController;
    private float timer;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerExperience = GetComponentInParent<PlayerExperience>();
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if(playerExperience.level == 3)
        {
            axe.SetActive(true);
            rb.AddForce(new Vector2(1, 1) * force);
        }
    }
}
