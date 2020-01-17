using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fukuten18.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fukuten18.Pages
{
    public class IndexModel : PageModel
    {
        private static ConcurrentDictionary<string, string> _data = new ConcurrentDictionary<string, string>();

        public IndexModel()
        {
        }

        public ICollection<string>? Items { get; set; }

        public async Task OnGetAsync()
        {
            #region Asynchronous streams / 非同期ストリーム

            Items ??= new List<string>();

            await foreach (var item in new Fukuten().GetObjectsAsync())
            {
                Items.Add(item);
            }

            #endregion

            #region Static local function / 静的ローカル関数

            var dataProvider = "hello";

            var data = GetDataFromCache("mykey", _data, dataProvider);

            static string GetDataFromCache(string key, ConcurrentDictionary<string, string> cache, string source)
            {
                var result = cache.GetOrAdd("mykey", (factory, arg) =>
                {
                    //return dataProvider;//❌
                    return arg;
                }, source);
                return result;
            }

            #endregion
        }
    }
}
