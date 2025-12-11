using UnityEngine;

public class SphereButtonMB : AObservable
{
    public override IActionClick GetAction()
    {
        IShape sphereShape = new ScaleDecorator(new RedColorDecorator(new Sphere()));
        Camera camera = Camera.main;
        LayerMask platformLayer = LayerMask.GetMask("Platform");

        return new CreateShape(sphereShape, camera, platformLayer);
    }
}
