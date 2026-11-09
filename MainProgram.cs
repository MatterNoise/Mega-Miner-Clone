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

        CurrentGameplayWorld.Close();

        RootBeer_MainSystem.CloseWindow(MainRenderingWindow);

        RootBeer_MainSystem.CloseInstance();
    }
}