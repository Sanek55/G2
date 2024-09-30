using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamBehaviour : MonoBehaviour
{
     
    private void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
       HandleCameraMovement();
=======
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
        Vector3 inputDir = new Vector3(0,0,0);


        if (Input.GetKey(KeyCode.W)) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;

        Vector3 moveDir = transform.forward *inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 300f;
        transform.position += inputDir*moveSpeed*Time.deltaTime;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)

        /*float rotateDir = 0f;
        if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) rotateDir = -1f;
        float rotateSpeed = 100f;

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);*/ // ������� ������ �� �������� ����

    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private void HandleCameraMovement()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);


        if (Input.GetKey(KeyCode.W)) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 300f;
        transform.position += inputDir * moveSpeed * Time.deltaTime;
    }
    private void HandleCameraZoom() 
    {
        
    }
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
=======
>>>>>>> parent of 0f540c5 (пиздец)
}

