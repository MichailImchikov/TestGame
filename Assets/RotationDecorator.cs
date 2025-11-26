using UnityEngine;

public class RotationDecorator : IShape
{
    private IShape wrapped;

    public RotationDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject CreateShape()
    {
        GameObject obj = wrapped.CreateShape();
        
        float originalHeight = obj.transform.position.y;
        
        obj.transform.Rotate(90f, 0f, 0f);
        
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            float halfHeight = renderer.bounds.extents.y;
            Vector3 currentPosition = obj.transform.position;
            currentPosition.y = halfHeight;
            obj.transform.position = currentPosition;
        }
        
        Debug.Log($"RotationDecorator applied rotation: {obj.transform.eulerAngles}");
        return obj;
    }
}
