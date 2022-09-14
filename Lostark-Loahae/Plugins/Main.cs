using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flow.Launcher.Plugin;

namespace Flow.Launcher.Plugin.Lostark
{
    public class Loahae : IPlugin
    {
        private const string Icon = "icon.png";
        private PluginInitContext _context;

        public void Init(PluginInitContext context)
        {
            _context = context;
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            if (!string.IsNullOrEmpty(query.Search))
            {
                results.Add(new Result
                {
                    Title = string.Format("{0} 검색", query.Search),
                    SubTitle = String.Format("로아해 사이트에서 {0} 캐릭터를 검색합니다.", query.Search),
                    IcoPath = Icon,
                    Action = c =>
                    {
                        _context.API.OpenUrl(string.Format("https://loahae.com/profile/{0}", query.Search));
                        return true;
                    }
                });
            }

            return results;
        }
    }
}