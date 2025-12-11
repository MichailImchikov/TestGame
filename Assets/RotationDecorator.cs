using UnityEngine;

public class RotationDecorator : Decorator
{
    public RotationDecorator(IShape shape) : base(shape)
    {
    }

    public override GameObject CreateShape()
    {
        GameObject obj = base.CreateShape();
        
        float originalHeight = obj.transform.position.y;
        
        obj.transform.Rotate(0f, 0f, 90f);
        
        Renderer renderer = obj.GetComponent<Renderer>();
/*        if (renderer != null)
        {
            float halfHeight = renderer.bounds.extents.y;
            Vector3 currentPosition = obj.transform.position;
            currentPosition.y = halfHeight;
            obj.transform.position = currentPosition;
        }*/
        
        Debug.Log($"RotationDecorator applied rotation: {obj.transform.eulerAngles}");
        return obj;
    }
}
