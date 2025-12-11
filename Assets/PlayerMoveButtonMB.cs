using UnityEngine;

public class PlayerMoveButtonMB : AObservable
{
    [SerializeField] private PlayerMB playerMB;

    public override IActionClick GetAction()
    {
        Camera camera = Camera.main;
        LayerMask platformLayer = LayerMask.GetMask("Platform");

        return new PlayerMove(playerMB, camera, platformLayer);
    }
}
