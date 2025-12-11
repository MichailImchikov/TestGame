using UnityEngine;

public class CubeButtonMB : AObservable
{
    public override IActionClick GetAction()
    {
        IShape cubeShape = new ScaleDecorator(new Cube());
        Camera camera = Camera.main;
        LayerMask platformLayer = LayerMask.GetMask("Platform");

        return new CreateShape(cubeShape, camera, platformLayer);
    }
}
