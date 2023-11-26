// See https://aka.ms/new-console-template for more information
using BlockchainBasicsApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var ran = new Random();
        IBlock genesis = new Block(new byte[] { 0x00, 0x00, 0x00, 0x00 });
        byte[] difficulty = new byte[] { 0x00, 0x00};
        BlockChain chain = new BlockChain(difficulty, genesis);
        Console.WriteLine(chain.LastOrDefault()?.ToString());
        if (chain.IsValid())
        {
            Console.WriteLine("offline blockchain is valid");
        }
        for (int i = 0; i < 3; i++)
        {
            var data = Enumerable.Range(0, 255).Select(p => (byte)ran.Next());
            chain.Add(new Block(data.ToArray()));
            Console.WriteLine(chain.LastOrDefault()?.ToString());
            if (chain.IsValid())
            {
                Console.WriteLine("blockchain is valid");
            }
        }     

        Console.ReadLine();
    }
}