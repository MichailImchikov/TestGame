using UnityEngine;

public class ScaleDecorator : Decorator
{
    public ScaleDecorator(IShape shape) : base(shape)
    {
    }

    public override GameObject CreateShape()
    {
        GameObject obj = base.CreateShape();
        
        float scaleMultiplier = 2f;
        obj.transform.localScale = obj.transform.localScale * scaleMultiplier;
        
        Vector3 currentPosition = obj.transform.position;
        currentPosition.y += (scaleMultiplier - 1f) * 0.5f;
        obj.transform.position = currentPosition;
        
        return obj;
    }
}
