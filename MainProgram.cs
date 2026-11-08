using System;
using SDL3;
using RootBeer_CS;

class MainProgram
{
    public static RenderingWindow? MainRenderingWindow;

    public static GameplayWorldClass CurrentGameplayWorld = new GameplayWorldClass();

    static void Main(string[] ParsedArguments)
    {
        RootBeer_MainSystem.InitInstance();

        MainRenderingWindow = RootBeer_MainSystem.CreateNewWindow("Hello world at the Main window!", 320, 240);
        SDL.SetDefaultTextureScaleMode(MainRenderingWindow.Renderer, SDL.ScaleMode.Nearest);

        /*WorldTilemap = new TilemapClass(
            SDL3.Image.LoadTexture(MainRenderingWindow.Renderer, "./Assets/Terrain.png"),
            20 * 8, 15 * 16
        );*/

        //WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 0, Y = 0, W = 16, H = 16 });
        //WorldTilemap.TilemapTileAtlas.Add(new SDL.FRect() { X = 16, Y = 0, W = 16, H = 16 });

        //WorldTilemap.SetTile(12, 5, 1);
        //WorldTilemap.SetTile(12, 6, 2);

        CurrentGameplayWorld.Init();

        while (RootBeer_MainSystem.GetWindowQuitAttempt() == false)
        {
            RootBeer_MainSystem.PollEvents();

            CurrentGameplayWorld.Update();

            RootBeer_RenderDrawSystem.SetCurrentRenderer(MainRenderingWindow.Renderer);

            CurrentGameplayWorld.Draw();

            RootBeer_RenderDrawSystem.UpdateRenderer();

            SDL.Delay(16);
        }

        RootBeer_MainSystem.CloseWindow(MainRenderingWindow);

        RootBeer_MainSystem.CloseInstance();
    }
}