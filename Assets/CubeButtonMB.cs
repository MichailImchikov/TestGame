using UnityEngine;

public class CubeButtonMB : ButtonMB
{
    [SerializeField] private PlayerMB playerMB;

    public override void OnClick()
    {
        if (playerMB != null)
        {
            IShape cubeShape = new ScaleDecorator(new Cube());
            Camera camera = Camera.main;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            
            CreateShape createShape = new CreateShape(cubeShape, camera, platformLayer);
            playerMB.GetNewAction(createShape);
        }
    }
}
