using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class PlayerEntityClass : EntityClass
{
    private bool PlayerInMovement = false;

    public override void Init()
    {
        OldTilePositionX = GameplayWorldClass.WorldTilemap.TilemapWidth / 2;
        OldTilePositionY = 0;
        
        TargetTilePositionX = GameplayWorldClass.WorldTilemap.TilemapWidth / 2;
        TargetTilePositionY = 0;
    }

    public override void Close()
    {
    }

    public override void Update()
    {
        if (PlayerInMovement == false)
        {
            bool LockPlayerMovementInY = false;
            if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.W))
            {
                TargetTilePositionY = TargetTilePositionY - 1;

                PlayerInMovement = true;
                MovementCuantity = 0;

                LockPlayerMovementInY = true;
            }
            if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.S))
            {
                TargetTilePositionY = TargetTilePositionY + 1;

                PlayerInMovement = true;
                MovementCuantity = 0;

                LockPlayerMovementInY = true;
            }
            
            if (LockPlayerMovementInY == false) { 
                if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.A))
                {
                    TargetTilePositionX = TargetTilePositionX - 1;

                    PlayerInMovement = true;
                    MovementCuantity = 0;
                }
                if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.D))
                {
                    TargetTilePositionX = TargetTilePositionX + 1;

                    PlayerInMovement = true;
                    MovementCuantity = 0;
                }
            }

            if (TargetTilePositionY < 9)
            {
                OldTilePositionY = 9;
                TargetTilePositionY = 9;
            }
        }

        /*if (GameplayWorldClass.WorldTilemap.GetTile(OldTilePositionX, OldTilePositionY) == TerrainTilesConstants.COAL_ORE_TILE)
        {
            GameplayWorldClass.PlayerMoney = GameplayWorldClass.PlayerMoney + 5;
        }*/

        if (MovementCuantity > 0.9999f)
        {
            PlayerInMovement = false;
        }

        MoveInTiles(0.25f);

        CameraClass.CameraX = (PositionX - 160) + 8;
        CameraClass.CameraY = (PositionY - 120) + 8;

        GameplayWorldClass.WorldTilemap.SetTile(OldTilePositionX, OldTilePositionY, 0);
    }

    public override void Draw()
    {
        RootBeer_RenderDrawSystem.SetDrawColor(0, 255, 255, 255);
        RootBeer_RenderDrawSystem.DrawRectFill(
            PositionX - CameraClass.CameraX,
            PositionY - CameraClass.CameraY,
            16,
            16
        );
    }
}
