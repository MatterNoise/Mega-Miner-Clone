using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

public class GameplayWorldClass : BaseTemplateClass
{
    private static PlayerEntityClass PlayerEntity = new PlayerEntityClass();
    public static TilemapClass FogOfWarTilemap;
    public static TilemapClass WorldTilemap;

    public static int PlayerMoney;

    public override void Init()
    {
        // Create a 32x32 chunk Tilemap (640x960 in tiles)
        nint? WorldTilemapTexture = SDL3.Image.LoadTexture(MainProgram.MainRenderingWindow.Renderer, "./Assets/Terrain.png");
        int WorldTilemapWidth = 32 * ChunkConstants.CHUNK_WIDTH;
        int WorldTilemapHeight = 32 * ChunkConstants.CHUNK_HEIGHT;

        if (WorldTilemapTexture == null)
        {
            return;
        }

        WorldTilemap = new TilemapClass(
            (nint)WorldTilemapTexture,
            WorldTilemapWidth,
            WorldTilemapHeight
        );

        TilesTextureHelperClass.DivideTextureIntoTiles(out WorldTilemap.TilemapTileAtlas, (nint)WorldTilemapTexture, 16, 16);

        TerrainGeneratorClass.SetCurrentTilemap(WorldTilemap);
        TerrainGeneratorClass.GenerateTerrain();

        CameraClass.CameraX = 0;
        CameraClass.CameraY = 0;

        PlayerEntity.PositionX = (WorldTilemap.TilemapWidth * ChunkConstants.CHUNK_TILE_SIZE) / 2;
        PlayerEntity.PositionY = 0;

        PlayerEntity.Init();
    }
    
    public override void Close()
    {
        PlayerEntity.Close();

        SDL.DestroyTexture((nint)WorldTilemap.TilemapTileTexture);
    }
    
    public override void Update()
    {
        PlayerEntity.Update();
    }
    
    public override void Draw()
    {
        RootBeer_RenderDrawSystem.SetDrawColor(0, 0, 0, 255);
        RootBeer_RenderDrawSystem.ClearScreen();

        WorldTilemap.DrawTilemap(
            -((int)CameraClass.CameraX % ChunkConstants.CHUNK_TILE_SIZE),
            -((int)CameraClass.CameraY % ChunkConstants.CHUNK_TILE_SIZE),
            (int)CameraClass.CameraX / ChunkConstants.CHUNK_TILE_SIZE,
            (int)CameraClass.CameraY / ChunkConstants.CHUNK_TILE_SIZE,
            21,
            16,
            ChunkConstants.CHUNK_TILE_SIZE
        );

        DebugDrawTilemapChunks();

        PlayerEntity.Draw();

        RootBeer_RenderDrawSystem.SetDrawColor(255, 255, 255, 255);
        SDL.RenderDebugText(RootBeer_RenderDrawSystem.CurrentRenderer, 2, 2, $"Monney: {PlayerMoney}");
    }

    private void DebugDrawTilemapChunks()
    {
        RootBeer_RenderDrawSystem.SetDrawColor(0, 255, 255, 255);

        int WorldChunksWidth = WorldTilemap.TilemapWidth / ChunkConstants.CHUNK_WIDTH;
        int WorldChunksHeight = WorldTilemap.TilemapHeight / ChunkConstants.CHUNK_HEIGHT;

        for (int IChunksY = 0; IChunksY < WorldChunksHeight; IChunksY++)
        {
            for (int IChunksX = 0; IChunksX < WorldChunksWidth; IChunksX++)
            {
                RootBeer_RenderDrawSystem.DrawRect(
                    -CameraClass.CameraX + (IChunksX * (ChunkConstants.CHUNK_WIDTH * ChunkConstants.CHUNK_TILE_SIZE)),
                    -CameraClass.CameraY + (IChunksY * (ChunkConstants.CHUNK_HEIGHT * ChunkConstants.CHUNK_TILE_SIZE)),
                    (ChunkConstants.CHUNK_WIDTH * ChunkConstants.CHUNK_TILE_SIZE),
                    (ChunkConstants.CHUNK_HEIGHT * ChunkConstants.CHUNK_TILE_SIZE)
                );
            }
        }
    }
}