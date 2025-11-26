using UnityEngine;

public class SphereButtonMB : ButtonMB
{
    [SerializeField] private PlayerMB playerMB;

    public override void OnClick()
    {
        if (playerMB != null)
        {
            IShape sphereShape = new RedColorDecorator(new Sphere());
            Camera camera = Camera.main;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            
            CreateShape createShape = new CreateShape(sphereShape, camera, platformLayer);
            playerMB.GetNewAction(createShape);
        }
    }
}
