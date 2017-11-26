using System.Threading;

namespace _3DGameDevelope
{
    class Program
    {
        static void Main(string[] args)
        {
            int ret = -1;
            Project.Start();

            do
            {
                Thread.Sleep(10);
                ret = Project.Update();
            } while (ret == 0);

            do
            {
                Thread.Sleep(1);
                ret = Project.FastUpdate();
            } while (ret == 0);
        }
    }
}
