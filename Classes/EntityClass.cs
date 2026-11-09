using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

public class EntityClass : BaseTemplateClass
{
    //public EntityClass() { }

    public float PositionX;
    public float PositionY;
    
    public int TargetTilePositionX;
    public int TargetTilePositionY;
    public int OldTilePositionX;
    public int OldTilePositionY;
    public float MovementCuantity;

    public void MoveInTiles(float _MovementCuantity)
    {
        if (MovementCuantity > 0.9999f)
        {
            OldTilePositionX = TargetTilePositionX;
            OldTilePositionY = TargetTilePositionY;
        }
        
        float OldPositionX = OldTilePositionX * ChunkConstants.CHUNK_TILE_SIZE;
        float OldPositionY = OldTilePositionY * ChunkConstants.CHUNK_TILE_SIZE;

        float NewPositionX = TargetTilePositionX * ChunkConstants.CHUNK_TILE_SIZE;
        float NewPositionY = TargetTilePositionY * ChunkConstants.CHUNK_TILE_SIZE;

        float PlayerPositionX = TweenClass.LERPInterpolate(OldPositionX, NewPositionX, MovementCuantity);
        float PlayerPositionY = TweenClass.LERPInterpolate(OldPositionY, NewPositionY, MovementCuantity);

        PositionX = PlayerPositionX;
        PositionY = PlayerPositionY;

        MovementCuantity = MovementCuantity + _MovementCuantity;
        MovementCuantity = ClampClass.Clamp(0.0f, 1.0f, MovementCuantity);
    }
}
