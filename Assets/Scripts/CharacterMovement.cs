using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Set in Inspector")]
    public float speed = 10f;


    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal"); // �������� a d;

        Vector3 position = transform.position; // ������� ����������� ��� �������

        position.x += xAxis * speed * Time.deltaTime; // �������� �����������

        transform.position = position; // �������� ���� �������
    }
}
