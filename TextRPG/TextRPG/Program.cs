namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TheGame theGame = new TheGame();

            theGame.Init();
            while (theGame.running)
            {
                theGame.Update();
            }
        }
    }
}
