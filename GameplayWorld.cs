using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

public class GameplayWorldClass : BaseTemplateClass
{
    private static PlayerEntityClass PlayerEntity = new PlayerEntityClass();
    public static TilemapClass WorldTilemap;
    
    public static Random GeneratorRandomDice;
    public static Random OreRandomDice;

    public static int PlayerMoney;

    public override void Init()
    {
        GeneratorRandomDice = new Random(0);
        OreRandomDice = new Random(0);

        // Create a 32x32 chunk Tilemap (640x960 in tiles)
        int WorldTilemapWidth = 32 * ChunkConstants.CHUNK_WIDTH;
        int WorldTilemapHeight = 32 * ChunkConstants.CHUNK_HEIGHT;

        WorldTilemap = new TilemapClass(
            SDL3.Image.LoadTexture(MainProgram.MainRenderingWindow.Renderer, "./Assets/Terrain.png"),
            WorldTilemapWidth,
            WorldTilemapHeight
        );

        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 0, Y = 0, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 16, Y = 0, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 32, Y = 0, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 48, Y = 0, W = 16, H = 16 });
        
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 0, Y = 16, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 16, Y = 16, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 32, Y = 16, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 48, Y = 16, W = 16, H = 16 });

        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 0, Y = 32, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 16, Y = 32, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 32, Y = 32, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 48, Y = 32, W = 16, H = 16 });

        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 0, Y = 48, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 16, Y = 48, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 32, Y = 48, W = 16, H = 16 });
        WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 48, Y = 48, W = 16, H = 16 });

        TerrainGeneratorClass.SetCurrentTilemap(WorldTilemap);
        TerrainGeneratorClass.GenerateTerrain();

        /*for (int IWorldHeight = 0; IWorldHeight < WorldTilemapHeight; IWorldHeight++) {
            for (int IWorldWidth = 0; IWorldWidth < WorldTilemapWidth; IWorldWidth++)
            {
                
                
                /*if (IWorldHeight < 10)
                {
                    continue;
                } else if (IWorldHeight == 10)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 1);

                    //continue;
                } else if (IWorldHeight > 10)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 2);
                }

                // TODO: Make the generation system not hardcoded
                if (GetGeneratorIncrementalResult(80, 180, IWorldHeight) == 0)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 3);
                }

                if (GetGeneratorIncrementalResult(280, 380, IWorldHeight) == 0)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 4);
                }

                // Coal
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 &&
                    OreRandomDice.Next(0, 100) == 0 &&
                    IWorldHeight > 10
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 5);
                }
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 &&
                    OreRandomDice.Next(0, 100) == 0 &&
                    IWorldHeight > 30
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 5);
                }
                // Copper
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 &&
                    OreRandomDice.Next(0, 50) == 0 &&
                    IWorldHeight > 60
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 6);
                }
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 &&
                    OreRandomDice.Next(0, 50) == 0 &&
                    IWorldHeight > 90
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 6);
                }
                // Silver
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 &&
                    OreRandomDice.Next(0, 50) == 0 &&
                    IWorldHeight > 120
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 7);
                }
                if (
                    WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 3 &&
                    OreRandomDice.Next(0, 40) == 0 &&
                    IWorldHeight > 150
                    )
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 7 + 4);
                }


                /*if (WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 && OreRandomDice.Next(0, 100) == 0)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 6);
                }
                if (WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 && OreRandomDice.Next(0, 100) == 0)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 7);
                }
                if (WorldTilemap.GetTile(IWorldWidth, IWorldHeight) == 2 && OreRandomDice.Next(0, 100) == 0)
                {
                    WorldTilemap.SetTile(IWorldWidth, IWorldHeight, 8);
                }
            }
        }*/

        CameraClass.CameraX = 0;
        CameraClass.CameraY = 0;

        PlayerEntity.PositionX = 0;
        PlayerEntity.PositionY = 0;

        PlayerEntity.Init();
    }
    
    public override void Close()
    {

    }
    
    public override void Update()
    {
        /*if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.W))
        {
            CameraClass.CameraY = CameraClass.CameraY - 8.0f;
        }
        if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.S))
        {
            CameraClass.CameraY = CameraClass.CameraY + 8.0f;
        }
        if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.A))
        {
            CameraClass.CameraX = CameraClass.CameraX - 8.0f;
        }
        if (RootBeer_KeyboardSystem.IsKeyHolded((UInt16)SDL.Scancode.D))
        {
            CameraClass.CameraX = CameraClass.CameraX + 8.0f;
        }*/

        CameraClass.CameraX++;

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

        //Console.WriteLine(WorldTilemap.TilemapWidth / 20);

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

    private int GetGeneratorIncrementalResult(int _StartGenerationY, int _EndGenerationY, int _CurrentYGeneration)
    {
        if (_CurrentYGeneration < _StartGenerationY)
        {
            return -1;
        }
        
        float GenerationStrength = _EndGenerationY - _StartGenerationY;

        int YGeneration = (int)MathF.Ceiling(GenerationStrength / (_CurrentYGeneration - _StartGenerationY));
        int GenerationResult = GeneratorRandomDice.Next(0, YGeneration);

        return GenerationResult;
    }
}