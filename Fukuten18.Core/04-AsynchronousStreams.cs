using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fukuten18.Core
{
    public class Fukuten
    {
        public string Name { get; set; } = nameof(Name);

        public async IAsyncEnumerable<string> GetObjectsAsync()
        {
            var source = new List<string>
            {
                Enumerable.Range(1,5),
                //Enumerable.Range(1,5).Select(_ => null as string),
                new[] { 5.1, 5.2, 5.3 },
                1,
                "200",
                3,
                new Fukuten { Name = nameof(Fukuten) },
                Number.Zero,
                Number.One,
                Number.Four,
                Number.Seven,
            };

            foreach (var item in source)
            {
                await Task.Delay(1); // simulate async I/O
                yield return item;
            }
        }
    }

    public enum Number
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven
    }

    #region Extensions

    public static class FukutenExtensions
    {
        public static void Add<T>(this List<string> list, IEnumerable<T> source) where T : notnull
        {
            list.AddRange(source switch
            {
                IEnumerable<int> i => i.Select(u => u.ToString()).ToList(),
                IEnumerable<double> d => d.Select(u => u.ToString()).ToList(),
                var e => Enumerable.Empty<string>()
            });
        }

        public static void Add<T>(this List<string> list, T source) where T : struct
        {
            list.Add(source switch
            {
                int i => $"{i * 100}🎈🎈🎈",
                Number number when number >= Number.One && number <= Number.Five => $"{number} => 1 ～ 5",
                Number number => $"{number} => 1 ～ 5 の範囲外！",
                var e => e.ToString(),
            });
        }

        public static void Add(this List<string> list, Fukuten fukuten) => list.Add(fukuten.Name);
    }

    #endregion
}
