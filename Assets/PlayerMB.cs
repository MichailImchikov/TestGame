using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMB : MonoBehaviour, PlayerInputController.IBaseActions, IObserver
{
    private PlayerInputController playerInputController;
    private CommandInvoker commandInvoker;
    private IActionClick _currentAction;

    [SerializeField] private LayerMask platformLayer;

    void Start()
    {
        playerInputController = new PlayerInputController();
        playerInputController.Base.AddCallbacks(this);
        playerInputController.Enable();
        commandInvoker = new CommandInvoker();
    }
    
    public void OnEsc(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            commandInvoker.Undo();
        }
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        if (context.performed && _currentAction != null)
        {
            _currentAction.Click(commandInvoker);
        }
    }
    
    public void GetNewAction(IActionClick action)
    {
        _currentAction = action;
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

    public void UpdateAction(IActionClick action)
    {
        _currentAction = action;
    }
}
