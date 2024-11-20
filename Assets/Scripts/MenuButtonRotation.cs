using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuButtonRotation : MonoBehaviour
{
    // Array to store the cubes (starting in the middle and going counter clockwise)
    public GameObject[] Cubes = new GameObject[5];

    // Array to store the possible positions (starting in the middle and going counter clockwise)
    public Vector3[] Positions = { new Vector3(0, 0, -2), new Vector3(2.3f, 0, -0.5f), new Vector3(1.5f, 0, 2), new Vector3(-1.5f, 0, 2), new Vector3(-2.3f, 0, -0.5f) };

    // Left half of the screen (with gap in the middle for the active button)
    Rect leftHalf = new Rect(0, 0, Screen.width / 2 - 100, Screen.height);

    // Right half of the screen (with gap in the middle for the active button)
    Rect rightHalf = new Rect(Screen.width / 2 + 100, 0, Screen.width / 2, Screen.height);

    // Variables for hovering
    public GameObject cubeParent;
    public float hoverHeight = 0.0004f;
    public float hoverSpeed = 2f;

    // Variables for movement of cubes
    public float moveDuration = 0.5f;

    // Activate the button only after a certain time when the cubes were moved
    public float lastIndexChangeTime;

    private InputAction fireAction;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();

        // Set up the input action for the mouse click (fire)
        fireAction = playerInput.Player.Fire;
    }

    private void OnEnable()
    {
        // Enable the fire action
        fireAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the fire action
        fireAction.Disable();
    }

    void Start()
    {
        lastIndexChangeTime = Time.time;
    }

    void Update()
    {
        // Check if the left mouse button was clicked using the new Input System
        if (fireAction.triggered)
        {
            // Click in the left half of the screen
            if (leftHalf.Contains(Mouse.current.position.ReadValue()))
            {
                RotateCubesLeft();
            }
            // Click in the right half of the screen
            else if (rightHalf.Contains(Mouse.current.position.ReadValue()))
            {
                RotateCubesRight();
            }
        }

        // Make Cubes hover up and down
        HoverCubes();
    }

    private void RotateCubesLeft()
    {
        // Copy last element
        GameObject temp = Cubes[Cubes.Length - 1];

        // Shift cubes in array to the right
        for (int i = Cubes.Length - 1; i > 0; i--)
        {
            Cubes[i] = Cubes[i - 1];
        }

        // Replace first element
        Cubes[0] = temp;

        lastIndexChangeTime = Time.time;

        // Start the smooth transition for each cube
        for (int i = 0; i < Cubes.Length; i++)
        {
            StartCoroutine(MoveToPosition(Cubes[i], Positions[i]));
        }
    }

    private void RotateCubesRight()
    {
        // Copy the first element
        GameObject temp = Cubes[0];

        // Shift cubes in array to the left
        for (int i = 0; i < Cubes.Length - 1; i++)
        {
            Cubes[i] = Cubes[i + 1];
        }

        // Place the first element at the end
        Cubes[Cubes.Length - 1] = temp;

        lastIndexChangeTime = Time.time;

        // Start the smooth transition for each cube
        for (int i = 0; i < Cubes.Length; i++)
        {
            StartCoroutine(MoveToPosition(Cubes[i], Positions[i]));
        }
    }

    private IEnumerator MoveToPosition(GameObject cube, Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = cube.transform.position;

        // Smoothly move to the target position over the specified duration
        while (elapsedTime < moveDuration)
        {
            cube.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure cube is exactly at the target position at the end
        cube.transform.position = targetPosition;
    }

    void HoverCubes()
    {
        // Calculate the new y-position using a sine wave
        float newY = cubeParent.transform.position.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Update the position of the cube
        cubeParent.transform.position = new Vector3(cubeParent.transform.position.x, newY, cubeParent.transform.position.z);
    }
}
