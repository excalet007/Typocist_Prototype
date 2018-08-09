using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region Singleton
    private static CameraController cameraController;

    public static CameraController Get_CameraController()
    {
        if (cameraController == null)
        {
            cameraController = FindObjectOfType<CameraController>().GetComponent<CameraController>();
            if (cameraController == null)
            {
                GameObject container = new GameObject();
                container.name = "CameraController";
                cameraController = container.AddComponent(typeof(CameraController)) as CameraController;
            }
        }
        return cameraController;
    }
    #endregion


    InputController inputController;

    Camera cam;
    
    Transform cam_Transform;
    Transform player_Trans;
    
    Vector3 vector3H = Vector3.right;
    Vector3 vector3V = Vector3.up;
    Vector3 vector3D = Vector3.back;

    
    const float shakeDuration = 0.5f;
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

        listRooms = new List<Room>();
        listRooms.Add(new Room(26.5f, -3.5f, 33f, 31f));
        listRooms.Add(new Room(6.5f, 1f, 7f, 2f));
        listRooms.Add(new Room(-3.5f, 1.5f, 13f, 11f));
        listRooms.Add(new Room(-5f, -8.5f, 4, 9));

        curRoom = listRooms[0];

        

    }
    
    private void LateUpdate()
    {
        Vector3 curPos = cam_Transform.position;
        Vector3 playerPos = player_Trans.position;
        Vector3 boundaryMove = playerPos;

        //Room Check
        float pX = playerPos.x;
        float pY = playerPos.y;
        if (pY > curRoom.y + curRoom.height / 2f || pY < curRoom.y - curRoom.height / 2f || pX < curRoom.x - curRoom.width / 2f || pX > curRoom.x + curRoom.width / 2f)
        {
            foreach (Room r in listRooms)
            {
                if (pY < r.y + r.height / 2f && pY > r.y - r.height / 2f && pX > r.x - r.width / 2f && pX < r.x + r.width / 2f)
                {
                    curRoom = r;
                    print("Room Change!");
                    break;
                }
            }
        }

        //Check in Boundary
        float halfHor = cam.orthographicSize * cam.aspect;
        float halfVer = cam.orthographicSize;

        bool topBound = false;
        bool bottomBound = false;
        bool leftBound = false;
        bool rightBound = false;
        
        //Boundary Check UP - Down - Left - Right
        if (boundaryMove.y + halfVer > curRoom.y + curRoom.height / 2f + uDemp) topBound = true;
        if (boundaryMove.y - halfVer < curRoom.y - curRoom.height / 2f - dDemp) bottomBound = true;
        if (boundaryMove.x - halfHor < curRoom.x - curRoom.width / 2f - lDemp) leftBound = true;
        if (boundaryMove.x + halfHor > curRoom.x + curRoom.width / 2f + rDemp) rightBound = true;

        if (topBound && bottomBound) ;
        else if(topBound) boundaryMove.y = curRoom.y + curRoom.height / 2f + uDemp - halfVer;
        else if(bottomBound) boundaryMove.y = curRoom.y - curRoom.height / 2f - dDemp + halfVer;

        if (leftBound && rightBound) ;
        else if(leftBound) boundaryMove.x = curRoom.x - curRoom.width / 2f - lDemp + halfHor;
        else if(rightBound) boundaryMove.x = curRoom.x + curRoom.width / 2f + rDemp - halfHor;




        // Shake Checker 
        Vector2 shakeVector = new Vector2();

        if (shakeTimer > 0f)
        {
            shakeVector = Random.insideUnitCircle * 0.1f * shakeTimer * shakePower ;
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
                shakePower = 1f;
        }
        else shakeVector = Vector2.zero;
        
        // Summation 
        cam_Transform.position = boundaryMove + (Vector3)shakeVector + vector3D;
    }

    public float shakePower = 1f;
    public void Shake(float duration, float power)
    {
        shakeTimer = duration;
        shakePower = power;
    }

}
