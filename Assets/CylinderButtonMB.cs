using UnityEngine;

public class CylinderButtonMB : ButtonMB
{
    [SerializeField] private PlayerMB playerMB;

    public override void OnClick()
    {
        if (playerMB != null)
        {
            IShape cylinderShape = /*new RotationDecorator(*/new Cylinder()/*)*/;
            Camera camera = Camera.main;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            
            CreateShape createShape = new CreateShape(cylinderShape, camera, platformLayer);
            playerMB.GetNewAction(createShape);
        }
    }
}
