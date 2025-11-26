using UnityEngine;

public class ScaleDecorator : IActionButtonClick
{
    private IActionButtonClick wrapped;

    public ScaleDecorator(IActionButtonClick wrapped)
    {
        this.wrapped = wrapped;
    }

    public GameObject Click(Vector3 position)
    {
        GameObject obj = wrapped.Click(position);
        
        float scaleMultiplier = 2f;
        obj.transform.localScale = obj.transform.localScale * scaleMultiplier;
        
        Vector3 currentPosition = obj.transform.position;
        currentPosition.y += (scaleMultiplier - 1f) * 0.5f;
        obj.transform.position = currentPosition;
        
        return obj;
    }
}
