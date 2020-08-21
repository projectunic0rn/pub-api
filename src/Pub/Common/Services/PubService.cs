using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Services
{
    public class PubService
    {
        private readonly Http.Http _http = new Http.Http();
        private readonly string _baseUri;
        private readonly Dictionary<string, string> headers = new Dictionary<string, string>();

        public PubService(string pubApiEndpoint, string apiKey)
        {
            _baseUri = pubApiEndpoint;
            headers.Add("X-Api-Key", apiKey);
        }

        public async Task<ResponseDto<List<ProjectDto>>> GetProjects()
        {
            ResponseDto<List<ProjectDto>> response = await _http.Get<ResponseDto<List<ProjectDto>>>($"{_baseUri}/projects?searchableonly=false", headers);
            return response;
        }

        public async Task<ResponseDto<List<CommunicationPlatformTypeDto>>> GetWorkspaces()
        {
            ResponseDto<List<CommunicationPlatformTypeDto>> response = await _http.Get<ResponseDto<List<CommunicationPlatformTypeDto>>>($"{_baseUri}/util/workspaces", headers);
            return response;
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto project)
        {
            var response = await _http.Put<ProjectDto>($"{_baseUri}/projects", headers, project);
            return response;
        }
    }
}
