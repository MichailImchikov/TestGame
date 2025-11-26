using UnityEngine;

public class CreateShapeCommand : ICommand
{
    private IShape shape;
    private Vector3 position;
    private GameObject createdObject;

    public CreateShapeCommand(IShape shape, Vector3 position)
    {
        this.shape = shape;
        this.position = position;
    }

    public void Execute()
    {
        createdObject = shape.CreateShape();
        createdObject.transform.position = createdObject.transform.localPosition + position;
    }

    public void Undo()
    {
        if (createdObject != null)
        {
            Object.Destroy(createdObject);
            createdObject = null;
        }
    }
}
