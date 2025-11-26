using UnityEngine;

public class PlayerMoveCommand : ICommand
{
    private PlayerMB player;
    private Vector3 previousPosition;
    private Vector3 newPosition;

    public PlayerMoveCommand(PlayerMB player, Vector3 newPosition)
    {
        this.player = player;
        this.newPosition = newPosition;
        this.previousPosition = player.transform.position;
    }

    public void Execute()
    {
        player.transform.position = newPosition;
    }

    public void Undo()
    {
        if (player != null)
        {
            player.transform.position = previousPosition;
        }
    }
}
