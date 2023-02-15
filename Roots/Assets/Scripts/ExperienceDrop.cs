using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDrop : MonoBehaviour
{
    [SerializeField] int experiencePoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            print("player pick up");
            PlayerExperience experienceCmp = collision.gameObject.GetComponent<PlayerExperience>();
            experienceCmp.AddExp(experiencePoints);
            Destroy(gameObject);
        }
    }
}
