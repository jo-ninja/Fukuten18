using System.Collections.Generic;
using System.Threading.Tasks;
using Fukuten18.Core;

namespace Fukuten18.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Asynchronous streams / 非同期ストリーム

            await foreach (var item in new Fukuten().GetObjectsAsync())
            {
                System.Console.WriteLine(item);
            }

            #endregion


            #region Readonly members / 読み取り専用メンバー

            System.Console.WriteLine(new Adder { A = 1, B = 2 });
            System.Console.ReadLine();

            #endregion
        }
    }
}
