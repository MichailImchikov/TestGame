using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMB : MonoBehaviour, PlayerInputController.IBaseActions
{
    private PlayerInputController playerInputController;
    private Camera mainCamera;
    private IShape sphereButton;
    private IShape cubeButton;
    private IShape cylinderButton;
    private CommandInvoker commandInvoker;

    [SerializeField] private LayerMask platformLayer;

    void Start()
    {
        playerInputController = new PlayerInputController();
        playerInputController.Base.AddCallbacks(this);
        playerInputController.Enable();

        mainCamera = Camera.main;
        commandInvoker = new CommandInvoker();
        
        sphereButton = new RedColorDecorator(new SphereButtonClick());
        cubeButton = new ScaleDecorator(new CubeButtonClick());
        cylinderButton = new RotationDecorator(new CylinderButtonClick());
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        if (playerInputController != null)
        {
            playerInputController.Base.RemoveCallbacks(this);
            playerInputController.Disable();
            playerInputController.Dispose();
        }
    }

    public void On_1Button(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 worldPosition = GetMouseWorldPosition();
            if (worldPosition != Vector3.zero)
            {
                CreateShapeCommand command = new CreateShapeCommand(sphereButton, worldPosition);
                commandInvoker.ExecuteCommand(command);
            }
        }
    }

    public void On_2Button(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 worldPosition = GetMouseWorldPosition();
            if (worldPosition != Vector3.zero)
            {
                CreateShapeCommand command = new CreateShapeCommand(cubeButton, worldPosition);
                commandInvoker.ExecuteCommand(command);
            }
        }
    }

    public void On_3Button(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 worldPosition = GetMouseWorldPosition();
            if (worldPosition != Vector3.zero)
            {
                CreateShapeCommand command = new CreateShapeCommand(cylinderButton, worldPosition);
                commandInvoker.ExecuteCommand(command);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        
        if (platformLayer != 0)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, platformLayer))
            {
                return hit.point;
            }
        }
        else
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
        }
        
        return Vector3.zero;
    }

    public void OnEsc(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            commandInvoker.Undo();
        }
    }
}
