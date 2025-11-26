using UnityEngine;

public class ScaleDecorator : IShape
{
    private IShape wrapped;

    public ScaleDecorator(IShape wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click()
    {
        GameObject obj = wrapped.Click();
        
        float scaleMultiplier = 2f;
        obj.transform.localScale = obj.transform.localScale * scaleMultiplier;
        
        Vector3 currentPosition = obj.transform.position;
        currentPosition.y += (scaleMultiplier - 1f) * 0.5f;
        obj.transform.position = currentPosition;
        
        return obj;
    }
}
