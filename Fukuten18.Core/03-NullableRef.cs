using System;

namespace Fukuten18.Core
{
    #region Nullable reference types / null 許容参照型

    public class StringTest
    {
        public void MyMethod(string? text)
        {
            //text = null;
            //text = null!;
            Console.WriteLine(text.ToLower());
            if (text != null)
            {
                Console.WriteLine(text.ToLower());
            }
        }
    }

    #endregion
}
