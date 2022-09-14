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
                    Title = string.Format("{0} �˻�", query.Search),
                    SubTitle = String.Format("�ξ��� ����Ʈ���� {0} ĳ���͸� �˻��մϴ�.", query.Search),
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