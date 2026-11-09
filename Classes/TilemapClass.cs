using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

public class TilemapClass : BaseTemplateClass
{
    public TilemapClass(nint _TilemapTileTexture, int _TilemapWidth, int _TilemapHeight)
    {
        this.TilemapTileTexture = _TilemapTileTexture;
        this.TilemapWidth = _TilemapWidth;
        this.TilemapHeight = _TilemapHeight;

        this.TilemapTiles = new int[TilemapWidth * TilemapHeight];
    }

    public List<SDL.FRect> TilemapTileAtlas = new List<SDL.FRect>();
    public nint? TilemapTileTexture;
    
    public int TilemapWidth;
    public int TilemapHeight;

    public int[] TilemapTiles;

    private bool CheckIfTileIsOfflimits(int _TileX, int _TileY)
    {
        if (
                _TileX < 0 ||
                _TileY < 0 ||
                _TileX >= TilemapWidth ||
                _TileY >= TilemapHeight
            )
        {
            return true;
        }
        
        return false;
    }

    public int GetTile(int _TileX, int _TileY)
    {
        if (CheckIfTileIsOfflimits(_TileX, _TileY) == true)
        {
            return -1;
        }
        
        return TilemapTiles[_TileX + _TileY * TilemapWidth];
    }
    public void SetTile(int _TileX, int _TileY, int _TileID)
    {
        if (CheckIfTileIsOfflimits(_TileX, _TileY) == true)
        {
            return;
        }

        TilemapTiles[_TileX + _TileY * TilemapWidth] = _TileID;
    }

    public void DrawTilemap(int _MapScreenX, int _MapScreenY, int _MapTileX = 0, int _MapTileY = 0, int _MapWidth = 20, int _MapHeight = 15, int _MapTileSize = 16)
    {
        if (TilemapTileTexture == null)
        {
            return;
        }

        for (int ITilemapHeight = 0; ITilemapHeight < _MapHeight; ITilemapHeight++)
        {
            for (int ITilemapWidth = 0; ITilemapWidth < _MapWidth; ITilemapWidth++)
            {
                int TilemapTileID = GetTile(ITilemapWidth + _MapTileX, ITilemapHeight + _MapTileY);
                if (TilemapTileID < 1)
                {
                    continue;
                }

                if (TilemapTileID > TilemapTileAtlas.Count)
                {
                    continue;
                }

                RootBeer_RenderDrawSystem.DrawRectTexture(
                    (nint)TilemapTileTexture,
                    (ITilemapWidth * _MapTileSize) + _MapScreenX,
                    (ITilemapHeight * _MapTileSize) + _MapScreenY,
                    _MapTileSize,
                    _MapTileSize,
                    TilemapTileAtlas[TilemapTileID - 1].X,
                    TilemapTileAtlas[TilemapTileID - 1].Y,
                    TilemapTileAtlas[TilemapTileID - 1].W,
                    TilemapTileAtlas[TilemapTileID - 1].H
                );
            }
        }
    }

    public static void GetChunkToLocalPosition()
    {

    }
}