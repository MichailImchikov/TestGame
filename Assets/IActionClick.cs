using UnityEngine;
using UnityEngine.InputSystem;

public interface IActionClick
{
    void Click(CommandInvoker commandInvoker);
}

public class CreateShape : IActionClick
{
    private IShape shape;
    private Camera mainCamera;
    private LayerMask platformLayer;

    public CreateShape(IShape shape, Camera camera, LayerMask layer)
    {
        this.shape = shape;
        this.mainCamera = camera;
        this.platformLayer = layer;
    }

    public void Click(CommandInvoker commandInvoker)
    {
        Vector3 position = GetPosition();
        if (position != Vector3.zero)
        {
            CreateShapeCommand command = new CreateShapeCommand(shape, position);
            commandInvoker.ExecuteCommand(command);
        }
    }

    private Vector3 GetPosition()
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
}

public class PlayerMove : IActionClick
{
    private PlayerMB playerObject;
    private Camera mainCamera;
    private LayerMask platformLayer;

    public PlayerMove(PlayerMB playerObject, Camera camera, LayerMask layer)
    {
        this.playerObject = playerObject;
        this.mainCamera = camera;
        this.platformLayer = layer;
    }

    public void Click(CommandInvoker commandInvoker)
    {
        Vector3 targetPosition = GetPosition();
        if (targetPosition != Vector3.zero)
        {
            Vector3 finalPosition = targetPosition + Vector3.up * 0.5f;
            PlayerMoveCommand command = new PlayerMoveCommand(playerObject, finalPosition);
            commandInvoker.ExecuteCommand(command);
        }
    }

    private Vector3 GetPosition()
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
}