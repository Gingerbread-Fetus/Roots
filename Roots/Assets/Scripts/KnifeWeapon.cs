using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : MonoBehaviour
{
    public float timeToAttack;
    public float attackDamage = 1f;
    public int level = 1;

    [SerializeField] ItemData itemData;
    [SerializeField] GameObject leftKnife;
    [SerializeField] GameObject rightKnife;
    [SerializeField] Vector2 knifeAttackSize;

    float timer;
    PlayerController playerController;
    PlayerExperience playerExperience;

    private void Awake()
    {
        playerExperience = GetComponentInParent<PlayerExperience>();
        playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
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

        if (playerExperience.level == 1)
        {
            if (playerController.lastHorizontalVector > 0)
            {
                rightKnife.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightKnife.transform.position, knifeAttackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftKnife.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftKnife.transform.position, knifeAttackSize, 0f);
                ApplyDamage(colliders);
            } 
        }
        else
        {
            rightKnife.SetActive(true);
            Collider2D[] rightColliders = Physics2D.OverlapBoxAll(rightKnife.transform.position, knifeAttackSize, 0f);
            ApplyDamage(rightColliders);

            leftKnife.SetActive(true);
            Collider2D[] leftColliders = Physics2D.OverlapBoxAll(leftKnife.transform.position, knifeAttackSize, 0f);
            ApplyDamage(leftColliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<Health>().dealDamage(attackDamage * itemData.damageByLevel[level]);
        }
    }

}
