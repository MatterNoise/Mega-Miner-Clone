using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

class TerrainGeneratorClass
{
    private static TilemapClass? CurrentTilemap;

    public static void SetCurrentTilemap(TilemapClass _Tilemap)
    {
        CurrentTilemap = _Tilemap;
    }

    public static void GenerateTerrain()
    {
        PlotTilesRect(0, 10, CurrentTilemap.TilemapWidth, CurrentTilemap.TilemapHeight, 2);
        PlotTilesRect(0, 24, CurrentTilemap.TilemapWidth, CurrentTilemap.TilemapHeight, 3);

        PlotTilesRect(0, 10, CurrentTilemap.TilemapWidth, 1, 1);
    }

    public static void PlotTilesRect(int _RectX, int _RectY, int _RectW, int _RectH, int _TileID)
    {
        if (CurrentTilemap == null)
        {
            return;
        }

        for (int IRectTileY = 0; IRectTileY < _RectH; IRectTileY++)
        {
            for (int IRectTileX = 0; IRectTileX < _RectW; IRectTileX++)
            {
                CurrentTilemap.SetTile(
                    IRectTileX + _RectX,
                    IRectTileY + _RectY,
                    _TileID
                );
            }
        }
    }
}