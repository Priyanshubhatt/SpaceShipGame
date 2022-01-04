using Godot;
using System;

public static class RandomNumberUtility
{
    private static RandomNumberGenerator randomNumberGenerator;

    private static void InitGenerator()
    {
        if (randomNumberGenerator == null)
            randomNumberGenerator = new RandomNumberGenerator();
    }

    public static float RandomFloat(float from, float to)
    {
        InitGenerator();

        return randomNumberGenerator.RandfRange(from, to);
    }

    public static int RandomInt(int from, int to)
    {
        InitGenerator();

        return randomNumberGenerator.RandiRange(from, to);
    }
}
