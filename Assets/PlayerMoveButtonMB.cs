using UnityEngine;

public class PlayerMoveButtonMB : ButtonMB
{
    [SerializeField] private PlayerMB playerMB;

    public override void OnClick()
    {
        if (playerMB != null)
        {
            Camera camera = Camera.main;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            
            PlayerMove playerMove = new PlayerMove(playerMB, camera, platformLayer);
            playerMB.GetNewAction(playerMove);
        }
    }
}
