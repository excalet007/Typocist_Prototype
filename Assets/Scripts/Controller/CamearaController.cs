using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearaController : MonoBehaviour {

    InputController inputController;

    Camera cam;
    
    Transform cam_Transform;
    Transform player_Trans;
    
    Vector3 vector3H = Vector3.right;
    Vector3 vector3V = Vector3.up;
    Vector3 vector3D = Vector3.back;

    
    const float shakeDuration = 1.5f;
    float shakeTimer = 0f;

    const float cam_MaxSize = 8f;
    const float cam_MinSize = 5f;

    const float uDemp = 5f;
    const float dDemp = 3f;
    const float lDemp = 3f;
    const float rDemp = 3f;

    public struct Room
    {
        public float x;
        public float y;
        public float width;
        public float height;
   
        public Room(float input_x, float input_y, float input_width, float input_height)
        {
            x = input_x;
            y = input_y;
            width = input_width;
            height = input_height;
        }
    }

    Room curRoom;
    List<Room> listRooms;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        cam_Transform = cam.transform;

        inputController = InputController.Get_InputController();
        player_Trans = inputController.Player.transform;

        cam.orthographicSize = cam_MinSize;
        cam_Transform.position = InputController.Get_InputController().Player.transform.position + vector3D;

        curRoom = new Room(26.5f, -3.5f, 33, 31);
        

    }
    
    private void LateUpdate()
    {
        Vector3 curPos = cam_Transform.position;
        Vector3 playerPos = player_Trans.position;
        Vector3 boundaryMove = playerPos;

        //Check in Boundary
        float halfHor = cam.orthographicSize * cam.aspect;
        float halfVer = cam.orthographicSize;

        //Boundary Check UP
        if (boundaryMove.y + halfVer > curRoom.y + curRoom.height / 2f + uDemp)
            boundaryMove.y = curRoom.y + curRoom.height / 2f + uDemp - halfVer;

        //Boundary Check Down
        if (boundaryMove.y - halfVer < curRoom.y - curRoom.height / 2f - dDemp)
            boundaryMove.y = curRoom.y - curRoom.height / 2f - dDemp + halfVer;

        //Boundary Check Left
        if (boundaryMove.x - halfHor < curRoom.x - curRoom.width / 2f - lDemp)
            boundaryMove.x = curRoom.x - curRoom.width / 2f - lDemp + halfHor;

        //Boundary Check Right
        if (boundaryMove.x + halfHor > curRoom.x + curRoom.width / 2f + rDemp)
            boundaryMove.x = curRoom.x + curRoom.width / 2f + rDemp - halfHor;

        Vector2 shakeVector = new Vector2();

        if (Input.GetKeyDown(KeyCode.Alpha4)) shakeTimer = shakeDuration;
        if (shakeTimer > 0f)
        {
            shakeVector = Random.insideUnitCircle * 0.1f * shakeTimer;
            shakeTimer -= Time.deltaTime;
        }
        else shakeVector = Vector2.zero;
        
        cam_Transform.position = boundaryMove + (Vector3)shakeVector + vector3D;
        

    }

}
