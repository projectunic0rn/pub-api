using System;
using System.Threading.Tasks;
using Common.Services;
using Xunit;

namespace PubJobs.IntegrationTests.WorkspaceInvitesTests
{
    public class WorkspaceInviteTests
    {
        [Fact]
        public async Task InviteTests_ValidateExpiredSlackInvite_ReturnsFalse()
        {
            //Arrange
            SlackService _workspaceService = new SlackService();
            string inviteLink = "https://join.slack.com/t/programmingbuddies-co/shared_invite/zt-d0ql429i-fbqV_e1iZWXErVrulp2Jng";
            //Act
            var result = await _workspaceService.GetInviteStatus(inviteLink);
            //Assert
            Assert.False(result.Valid);
        }

        [Fact]
        public async Task InviteTests_ValidateSlackInviteNotExpired_ReturnsTrue()
        {
            //Arrange
            SlackService _workspaceService = new SlackService();
            string inviteLink = "https://join.slack.com/t/project-unic0rn/shared_invite/enQtNzUyNTA1OTgzNzE5LWJmNDYyMjQ0M2U0NmE1NGQ3NTYzYjE3MGQyOTg4ZmU1MDlhOTRlZWVhOTBmMTgxNmI2ZGRhYWExNTVmYmE0ZDI";
            //Act
            var result = await _workspaceService.GetInviteStatus(inviteLink);
            //Assert
            Assert.True(result.Valid);
        }

        [Fact]
        public async Task InviteTests_ValidateDiscorcdInviteNotExpired_ReturnsTrue()
        {
            //Arrange
            DiscordService _workspaceService = new DiscordService();
            string inviteLink = "https://discord.gg/GmurfHD";
            //Act
            var result = await _workspaceService.GetInviteStatus(inviteLink);
            //Assert
            Assert.True(result.Valid);
        }

        [Fact]
        public async Task InviteTests_ValidateDiscorcdInviteExpired_ReturnsFalse()
        {
            //Arrange
            DiscordService _workspaceService = new DiscordService();
            string inviteLink = "https://discordapp.com/invite/BFydMyn";
            //Act
            var result = await _workspaceService.GetInviteStatus(inviteLink);
            //Assert
            Assert.False(result.Valid);
        }
    }
}
