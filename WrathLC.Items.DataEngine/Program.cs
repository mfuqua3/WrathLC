//search 1-53000?

using System;
using System.Threading.Tasks;

namespace WrathLC.Items.DataEngine;

public static class Program
{
    public static async Task Main()
    {
        //var seed = new WowheadSeed();
        var seed = new PostgresSeed();
        await seed.RunAsync();
        Console.Read();
    }

    
}