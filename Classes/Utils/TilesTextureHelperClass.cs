using System;
using SDL3;
using RootBeer_CS;
using GameClasses;

public class TilesTextureHelperClass
{
    public static void DivideTextureIntoTiles(out List<SDL.FRect> _TilesTextureAtlas, nint _TilesTexture, int _TileWidth, int _TileHeight)
    {
        List<SDL.FRect> TilesTextureAtlas = new List<SDL.FRect>();

        SDL.GetTextureSize((nint)_TilesTexture, out float TextureWidth, out float TextureHeight);

        int TextureWidthInTiles = (int)TextureWidth / _TileWidth;
        int TextureHeightInTiles = (int)TextureHeight / _TileHeight;
        for (int ITextureTileY = 0; ITextureTileY < TextureHeightInTiles; ITextureTileY++)
        {
            for (int ITextureTileX = 0; ITextureTileX < TextureWidthInTiles; ITextureTileX++)
            {
                SDL.FRect TileAtlasRect = new SDL.FRect() {
                    X = ITextureTileX * _TileWidth,
                    Y = ITextureTileY * _TileHeight,
                    W = _TileWidth,
                    H = _TileWidth
                };

                TilesTextureAtlas.Add(TileAtlasRect);
            }
        }

        _TilesTextureAtlas = TilesTextureAtlas;
    }
}