using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Set in Inspector")]
    public float speed = 10f;


    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal"); // получаем a d;

        Vector3 position = transform.position; // создаем плейсхолдер для позиции

        position.x += xAxis * speed * Time.deltaTime; // изменяем плейсхолдер

        transform.position = position; // изменяем свою позицию
    }
}
