using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantClimb : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject character;
    public GameObject plant;
    public GameObject pressButtonDisclaimer;
    public float climbingSpeed = 5;

    public static bool isClimbing = false;

    private bool isColliding = false;

    private void Awake()
    {
        plant.SetActive(false);
        pressButtonDisclaimer.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnt");
        isColliding = true;
        pressButtonDisclaimer.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExi");
        isColliding = false;
    }
   
    void createPlant()
    {
        if (isColliding && Input.GetKey(KeyCode.E))
        {
            plant.SetActive(true);
        }
    }

    private void climb()
    {
        
        if(plant.activeInHierarchy == true && isColliding && Input.GetKey(KeyCode.Space))
        {
            Vector3 position = character.transform.position;
            position.x += climbingSpeed;
            position.y = plant.transform.position.y;
            character.transform.position = position;
        }
    }
    void LateUpdate()
    {
            
    }
}
