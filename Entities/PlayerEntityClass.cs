using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class PlayerEntityClass : EntityClass
{
    private int OldTilePositionX = 0;
    private int OldTilePositionY = 0;
    private int TargetTilePositionX = 0;
    private int TargetTilePositionY = 0;

    private float MovementCuantity = 1;

    private bool PlayerInMovement = false;

    public override void Init()
    {
        OldTilePositionX = (int)PositionX / ChunkConstants.CHUNK_TILE_SIZE;
        OldTilePositionY = (int)PositionY / ChunkConstants.CHUNK_TILE_SIZE;
        TargetTilePositionX = (int)PositionX / ChunkConstants.CHUNK_TILE_SIZE;
        TargetTilePositionY = (int)PositionY / ChunkConstants.CHUNK_TILE_SIZE;
    }

    public override void Close()
    {
    }

    public override void Update()
    {
        if (PlayerInMovement == false)
        {
            OldTilePositionX = TargetTilePositionX;
            OldTilePositionY = TargetTilePositionY;

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
                TargetTilePositionY = 9;
            }
        }

        if (GameplayWorldClass.WorldTilemap.GetTile(OldTilePositionX, OldTilePositionY) == 5)
        {
            GameplayWorldClass.PlayerMoney = GameplayWorldClass.PlayerMoney + 5;
        }
        if (GameplayWorldClass.WorldTilemap.GetTile(OldTilePositionX, OldTilePositionY) == 6)
        {
            GameplayWorldClass.PlayerMoney = GameplayWorldClass.PlayerMoney + 20;
        }
        if (GameplayWorldClass.WorldTilemap.GetTile(OldTilePositionX, OldTilePositionY) == 7)
        {
            GameplayWorldClass.PlayerMoney = GameplayWorldClass.PlayerMoney + 50;
        }

        float OldPositionX = OldTilePositionX * ChunkConstants.CHUNK_TILE_SIZE;
        float OldPositionY = OldTilePositionY * ChunkConstants.CHUNK_TILE_SIZE;

        float NewPositionX = TargetTilePositionX * ChunkConstants.CHUNK_TILE_SIZE;
        float NewPositionY = TargetTilePositionY * ChunkConstants.CHUNK_TILE_SIZE;

        float PlayerPositionX = TweenClass.LERPInterpolate(OldPositionX, NewPositionX, MovementCuantity);
        float PlayerPositionY = TweenClass.LERPInterpolate(OldPositionY, NewPositionY, MovementCuantity);

        if (GameplayWorldClass.WorldTilemap.GetTile(TargetTilePositionX, TargetTilePositionY) % 4 == 0)
        {
            MovementCuantity = MovementCuantity + 0.20f;
        } else
        {
            MovementCuantity = MovementCuantity + 0.10f;
        }


        MovementCuantity = ClampClass.Clamp(0.0f, 1.0f, MovementCuantity);

        if (MovementCuantity > 0.9999f)
        {
            PlayerInMovement = false;
        }

        PositionX = PlayerPositionX;
        PositionY = PlayerPositionY;

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
