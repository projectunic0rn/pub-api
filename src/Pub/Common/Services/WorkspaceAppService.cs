using System.Collections.Generic;
using Common.DTOs.WorkspaceAppDTOs;
using System.Threading.Tasks;

namespace Common.Services
{
    /// <summary>
    /// WorkspaceAppService retrieves information
    /// from the workspace app web service. Workspace
    /// apps expose a /info endpoint with details of
    /// the app.
    /// 
    /// More info on workspace apps at this repo.
    /// https://github.com/projectunic0rn/pub-workspace
    /// </summary>
    public class WorkspaceAppService
    {
        private readonly Http.Http _http = new Http.Http();
        private readonly Dictionary<string, string> _baseUrls;

        public WorkspaceAppService(Dictionary<string, string> baseUrls)
        {
            _baseUrls = baseUrls;
        }

        /// <summary>
        /// Retrieve the installation url for a given workspace app
        /// </summary>
        /// <param name="workspaceType"></param>
        /// <returns>An installation url</returns>
        public async Task<string> GetInstallUrl(string workspaceType)
        {
            string baseUrl = ResolveBaseUri(workspaceType);
            InfoDto response = await _http.Get<InfoDto>($"{baseUrl}/info");
            string installUrl = response.InstallUrl;
            return installUrl;
        }

        /// <summary>
        /// Retrieve the proper api url for a given workspace type.
        /// </summary>
        /// <param name="workspaceType">Type of workspace e.g. 'slack', 'discord'</param>
        /// <returns>An api url</returns>
        private string ResolveBaseUri(string workspaceType)
        {
            string baseUrl = _baseUrls[workspaceType];
            return baseUrl;
        }
    }
}
