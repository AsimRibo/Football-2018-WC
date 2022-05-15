using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities.DAL
{
    public static class RepositoryFactory
    {
        public static IDataHandling GetRepository(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Online:
                    return new APIFootballDataHandler();
                case ConnectionType.Offline:
                    return new FileFootballDataHandler();
                default:
                    return new APIFootballDataHandler();
            }
        }

        public static ISettings GetSettings() => new UserFileRepository();

    }
}