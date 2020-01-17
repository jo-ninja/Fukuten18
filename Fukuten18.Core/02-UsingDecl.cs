using System;

namespace Fukuten18.Core
{
    #region Using declaration / using 宣言

    public class UsingDecl
    {
        void SampleUsingDecl<T>(T disposable1, T disposable2, T disposable3) where T : IDisposable
        {
            using var one = disposable1;
            using var two = disposable2;
            using var three = disposable3;

            // ...
        }
    }

    #endregion
}
