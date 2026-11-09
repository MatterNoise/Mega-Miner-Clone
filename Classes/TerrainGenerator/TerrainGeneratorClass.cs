using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class TerrainGeneratorClass
{
    private static TilemapClass? CurrentTilemap;

    public static int TerrainGenerationSeed = 0;

    public static void SetCurrentTilemap(TilemapClass _Tilemap)
    {
        CurrentTilemap = _Tilemap;
    }

    public static void GenerateTerrain()
    {
        if (CurrentTilemap == null)
        {
            return;
        }
        
        PlotTilesRect(0, 10, CurrentTilemap.TilemapWidth, CurrentTilemap.TilemapHeight, TerrainTilesConstants.DIRT_TILE);
        PlotTilesRect(0, 200, CurrentTilemap.TilemapWidth, CurrentTilemap.TilemapHeight, TerrainTilesConstants.STONE_TILE);
        PlotTilesRect(0, 400, CurrentTilemap.TilemapWidth, CurrentTilemap.TilemapHeight, TerrainTilesConstants.HARD_STONE_TILE);

        PlotRandomTilesRect(
            0, 11,
            CurrentTilemap.TilemapWidth, 200,
            TerrainTilesConstants.COAL_ORE_TILE,
            0.01f
        );
        PlotRandomTilesRect(
            0, 30,
            CurrentTilemap.TilemapWidth, 200,
            TerrainTilesConstants.COAL_ORE_TILE,
            0.02f
        );

        PlotRandomTilesRect(
            0, 60,
            CurrentTilemap.TilemapWidth, 200,
            TerrainTilesConstants.COPPER_ORE_TILE,
            0.01f
        );
        PlotRandomTilesRect(
            0, 90,
            CurrentTilemap.TilemapWidth, 200,
            TerrainTilesConstants.COPPER_ORE_TILE,
            0.02f
        );

        PlotRandomTilesRect(
            0, 200,
            CurrentTilemap.TilemapWidth, 400,
            TerrainTilesConstants.COPPER_ORE_TILE + 16,
            0.02f
        );
        
        PlotRandomTilesRect(
            0, 230,
            CurrentTilemap.TilemapWidth, 400,
            TerrainTilesConstants.SILVER_ORE_TILE + 16,
            0.01f
        );
        PlotRandomTilesRect(
            0, 290,
            CurrentTilemap.TilemapWidth, 400,
            TerrainTilesConstants.SILVER_ORE_TILE + 16,
            0.02f
        );

        PlotRandomTilesRect(
            0, 320,
            CurrentTilemap.TilemapWidth, 400,
            TerrainTilesConstants.GOLD_ORE_TILE + 16,
            0.02f
        );
        PlotRandomTilesRect(
            0, 360,
            CurrentTilemap.TilemapWidth, 400,
            TerrainTilesConstants.GOLD_ORE_TILE + 16,
            0.02f
        );



        PlotTilesRect(0, 10, CurrentTilemap.TilemapWidth, 11, 1);
    }

    public static void PlotTilesRect(int _RectStartX, int _RectStartY, int _RectEndX, int _RectEndY, int _TileID)
    {
        if (CurrentTilemap == null)
        {
            return;
        }

        for (int IRectTileY = _RectStartY; IRectTileY < _RectEndY; IRectTileY++)
        {
            for (int IRectTileX = _RectStartX; IRectTileX < _RectEndX; IRectTileX++)
            {
                CurrentTilemap.SetTile(
                    IRectTileX,
                    IRectTileY,
                    _TileID
                );
            }
        }
    }
    
    public static void PlotRandomTilesRect(int _RectStartX, int _RectStartY, int _RectEndX, int _RectEndY, int _TileID, float _TileRandomMax = 0.5f)
    {
        if (CurrentTilemap == null)
        {
            return;
        }

        Random TileRandomDice = new Random(TerrainGenerationSeed);
        for (int IRectTileY = _RectStartY; IRectTileY < _RectEndY; IRectTileY++)
        {
            for (int IRectTileX = _RectStartX; IRectTileX < _RectEndX; IRectTileX++)
            {
                if (TileRandomDice.NextSingle() > _TileRandomMax)
                {
                    continue;
                }
                
                CurrentTilemap.SetTile(
                    IRectTileX,
                    IRectTileY,
                    _TileID
                );
            }
        }
    }

    
}