using System;
using Newtonsoft.Json;

namespace Common.DTOs.WorkspaceAppDTOs
{
    public class InviteDto
    {
        public InviteDto(bool valid)
        {
            Valid = valid;
        }

        public bool Valid { get; set; }
    }
}
