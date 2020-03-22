using System;
using Common.AppSettings;
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
        private readonly string _authToken;

        public PubService(Settings settings)
        {
            _baseUri = settings.PubApiEndpoint;
        }

        public async Task<ResponseDto<List<ProjectDto>>> GetProjects()
        {
            ResponseDto<List<ProjectDto>> response = await _http.Get<ResponseDto<List<ProjectDto>>>($"{_baseUri}/projects", headers);
            return response;
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto project)
        {
            var response = await _http.Put<ProjectDto>($"{_baseUri}/projects", headers);
            return response;
        }
    }
}
