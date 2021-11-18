using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject character;
    public GameObject camera;

    private void LateUpdate()
    {
        Vector3 characterPos = character.transform.position;

        camera.transform.position = new Vector3(characterPos.x, characterPos.y, camera.transform.position.z);
    }
}