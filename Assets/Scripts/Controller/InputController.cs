using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

    #region Singleton
    private static InputController inputController;

    public static InputController Get_InputController()
    {
        if(inputController == null)
        {
            inputController = FindObjectOfType<InputController>().GetComponent<InputController>();
            if(inputController == null)
            {
                GameObject container = new GameObject();
                container.name = "InputController";
                inputController = container.AddComponent(typeof(InputController)) as InputController;
            }            
        }
        return inputController;
    }
    #endregion

    #region Field
    public Transform Player;
    public List<WordOwner> List_WordOwner;
    
    private KeyCode button_Up;
    private KeyCode button_Down;
    private KeyCode button_Left;
    private KeyCode button_Right;
    private KeyCode button_Shift;
    
    private Vector3 move;
    public float moveSpeed;

    private SpriteRenderer player_SRenderer;
    #endregion

    void Start()
    {
        // Initialize Collection
        List_WordOwner = new List<WordOwner>();

        // Find Collection
        WordOwner[] container_WordOwner = FindObjectsOfType<WordOwner>();
        foreach (WordOwner _wordOwner in container_WordOwner)
            List_WordOwner.Add(_wordOwner);

        // Key Setting
        button_Up = KeyCode.I;
        button_Down = KeyCode.K;
        button_Left = KeyCode.J;
        button_Right = KeyCode.L;
        button_Shift = KeyCode.LeftShift;

        // Initialize Variable
        move = Vector3.zero;
        moveSpeed = 8f;

        // Initalize Link
        player_SRenderer = Player.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        #region Player Movement
        if (Input.GetKey(button_Shift))
        {
            if (Input.GetKey(button_Up))
                move += new Vector3(0, 1, 0);
            if (Input.GetKey(button_Down))
                move += new Vector3(0, -1, 0);
            if (Input.GetKey(button_Left))
                move += new Vector3(-1, 0, 0);
            if (Input.GetKey(button_Right))
                move += new Vector3(1, 0, 0);

            if (move != Vector3.zero)
            {
                // Look at - Change
                if (move.x > 0)
                    player_SRenderer.flipX = false;
                if (move.x < 0)
                    player_SRenderer.flipX = true;

                // Detacting Obstacles


                // Normalize Value & Move
                move = move.normalized;
                Player.GetComponentInChildren<Rigidbody2D>().MovePosition(Player.transform.position + move*Time.deltaTime*moveSpeed);

                // Re-Initialize
                move = Vector3.zero;
            }
            
        }
        #endregion

        #region Word Detection
        if(Input.GetKey(button_Shift) == false)
        {
            if (Input.inputString.Length > 0)
            {
                char _typed = Input.inputString[0];

                foreach(WordOwner _wordOwner in List_WordOwner)
                {
                    //_wordOwner.List_Word[0].Check_Typed(_typed);
                }

            }
        }
        #endregion

        #region Fast_Debugging
        if (Input.GetKey(KeyCode.Alpha9))
            moveSpeed -= 0.1f;

        if (Input.GetKey(KeyCode.Alpha0))
            moveSpeed += 0.1f;

        if (Input.GetKey(KeyCode.Home))
            SceneManager.LoadScene("Stage");

        #endregion

    }


}
