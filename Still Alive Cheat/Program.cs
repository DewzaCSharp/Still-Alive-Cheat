using ClickableTransparentOverlay;
using ImGuiNET;
using Swed64;
using System.Numerics;

public class Program : Overlay
{
    public bool infammo = false;
    Swed swed = new Swed("STILL ALIVE");
    protected override void Render()
    {
        DrawMenu();
    }
    public void DrawMenu()
    {
        ImGui.SetNextWindowSize(new Vector2(300, 300));
        ImGui.Begin("cheat");
        ImGui.Checkbox("inf ammo", ref infammo);
        ImGui.Text("made by dewzacsharp in 5 minutes");
        if (infammo)
        {
            long longAddress = 0x1E0B0FB0F31;
            long othergunlongAddress = 0x1DFE4208EB9;

            nint nativeAddress = checked((nint)longAddress);
            nint othergunnativeAddress = checked((nint)othergunlongAddress);

            byte[] originalbytes = { 0x89, 0x46, 0x60 };
            byte[] newBytes = { 0x90, 0x90, 0x90 };
            swed.WriteBytes(nativeAddress, newBytes);
            swed.WriteBytes(othergunnativeAddress, newBytes);
        }
        else if (!infammo)
        {
            long pewpewlongAddress = 0x1E0B0FB0F31;
            long othergunlongAddress = 0x1DFE4208EB9;

            nint nativeAddress = checked((nint)pewpewlongAddress);
            nint othergunnativeAddress = checked((nint)othergunlongAddress);

            byte[] originalbytes = { 0x89, 0x46, 0x60 };
            swed.WriteBytes(nativeAddress, originalbytes);
            swed.WriteBytes(othergunnativeAddress, originalbytes);
        }
        ImGui.End();
    }
    public static void Main()
    {
        Console.WriteLine("starting...");
        var program = new Program();
        program.Start();
        Console.WriteLine("started cheat.");
    }
}