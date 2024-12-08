using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuButtonRotation : MonoBehaviour
{
    public GameObject[] Cubes = new GameObject[5];
    public Vector3[] Positions = { new Vector3(0, 0, -2), new Vector3(2.3f, 0, -0.5f), new Vector3(1.5f, 0, 2), new Vector3(-1.5f, 0, 2), new Vector3(-2.3f, 0, -0.5f) };
    Rect leftHalf = new Rect(0, 0, Screen.width / 2 - 100, Screen.height);
    Rect rightHalf = new Rect(Screen.width / 2 + 100, 0, Screen.width / 2, Screen.height);
    public GameObject cubeParent;
    public float hoverHeight = 0.0004f;
    public float hoverSpeed = 2f;
    public float moveDuration = 0.5f;
    public float lastIndexChangeTime;
    private InputAction fireAction;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        fireAction = playerInput.Player.Fire;
    }

    private void OnEnable()
    {
        fireAction.Enable();
    }

    private void OnDisable()
    {
        fireAction.Disable();
    }

    void Start()
    {
        lastIndexChangeTime = Time.time;
    }

    void Update()
    {
        if (fireAction.triggered)
        {
            // Click in left half of screen
            if (leftHalf.Contains(Mouse.current.position.ReadValue()))
            {
                RotateCubesLeft();
            }
            // Click in right half of screen
            else if (rightHalf.Contains(Mouse.current.position.ReadValue()))
            {
                RotateCubesRight();
            }
        }
        HoverCubes();
    }

    private void RotateCubesLeft()
    {
        // Shift cubes in array to the right
        GameObject temp = Cubes[Cubes.Length - 1];
        for (int i = Cubes.Length - 1; i > 0; i--)
        {
            Cubes[i] = Cubes[i - 1];
        }
        Cubes[0] = temp;

        lastIndexChangeTime = Time.time;

        // Move cubes
        for (int i = 0; i < Cubes.Length; i++)
        {
            StartCoroutine(MoveToPosition(Cubes[i], Positions[i]));
        }
    }

    private void RotateCubesRight()
    {
        // Shift cubes in array to left
        GameObject temp = Cubes[0];
        for (int i = 0; i < Cubes.Length - 1; i++)
        {
            Cubes[i] = Cubes[i + 1];
        }
        Cubes[Cubes.Length - 1] = temp;
        lastIndexChangeTime = Time.time;

        // Move cubes
        for (int i = 0; i < Cubes.Length; i++)
        {
            StartCoroutine(MoveToPosition(Cubes[i], Positions[i]));
        }
    }

    private IEnumerator MoveToPosition(GameObject cube, Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = cube.transform.position;

        // Move cube to target position
        while (elapsedTime < moveDuration)
        {
            cube.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cube.transform.position = targetPosition;
    }

    void HoverCubes()
    {
        // Update y-position using sine wave
        float newY = cubeParent.transform.position.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        cubeParent.transform.position = new Vector3(cubeParent.transform.position.x, newY, cubeParent.transform.position.z);
    }
}
