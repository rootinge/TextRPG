namespace TextRPG
{
    public interface IScene
    {
        void Init();
        void Update();
        void Clear();
    }

    // 부모 클래스
    internal class Scene : IScene
    {
        protected int choice = 0;
        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Clear() { }

        protected int currentState;
        // 행동 입력
        protected int BehaviorCheck(int min, int max)
        {
            int input;


            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string? line = Console.ReadLine();
                Console.WriteLine();

                if (line == null)
                {
                    Console.WriteLine("입력이 없습니다.");
                    continue;
                }
                else if (int.TryParse(line, out input))
                {
                    if (input >= min && input <= max)
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine($"잘못된 입력입니다. {min}부터 {max} 사이의 숫자를 입력해주세요.");
                    }
                }
                else
                {
                    // 만약 숫자가 아니였을 때
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                }
            }
        }

        protected void Loading()
        {
            //Console.Write("\n로딩중");
            //Thread.Sleep(300);
            //Console.Write(".");
            //Thread.Sleep(300);
            //Console.Write(".");
            //Thread.Sleep(300);
            //Console.Write(".");
            //Thread.Sleep(300);
        }
    }
}
