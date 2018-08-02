using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearaController : MonoBehaviour {

    private Transform cam_Transform;
    private Camera cam;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        cam_Transform = cam.GetComponent<Transform>();
    }

    private void Update()
    {
        cam_Transform.position = InputController.Get_InputController().Player.transform.position + new Vector3(0f, 0f, -1f);

        if (Input.GetKey(KeyCode.Alpha7))
            cam.orthographicSize -= 0.05f;
        if (Input.GetKey(KeyCode.Alpha8))
            cam.orthographicSize += 0.05f;
    }

}
