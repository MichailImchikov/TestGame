using UnityEngine;

public class CylinderButtonMB : AObservable
{
    public override IActionClick  GetAction()
    {
            IShape cylinderShape = /*new RotationDecorator(*/new Cylinder()/*)*/;
            Camera camera = Camera.main;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            
            return new CreateShape(cylinderShape, camera, platformLayer);
    }
}
