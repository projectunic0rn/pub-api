using Common.AppSettings;

namespace CommunicationAppDomain.ChatMessages
{
    public static class Messages
    {
        private static string _frontendUrl = AppSettings.MainUrl;
        private static string _appUrl = AppSettings.AppUrl;
        public static string OnboardingMessage(string slackId, string signinId, string signinPassword)
        {
            string message = $"Welcome to the slack team <@{slackId}>! Below is a short checklist of things to do in order to start or join a project.\n\n*1. Join the Project Unicorn GitHub org :github:*\n Use the `/github-connect` slack command on slack to join the GitHub org.\n\n*2. View available projects :computer:*\n Find projects using the `/projects` slack command to see a list of projects looking for members or view the <{_appUrl}/projects|projects page>.\n\n*3. Join a project :projectunicorn:*\n Login to the ui with the `/magic-login-link` slack command or visit {_frontendUrl} with the credentials below. Once authenticated, visit the project page and click 'Join Project'.\n email: `{signinId}` \n password: `{signinPassword}`\n\n*Starting your own project*\nYou can also start a project through the <{_appUrl}/projects|projects page>! To find find members interested in joining your project you can search for them on the <{_appUrl}/members|members page>. You can also recruit members to join your project who aren't already on the slack team using <https://join.slack.com/t/project-unic0rn/shared_invite/enQtNzUyNTA1OTgzNzE5LWJmNDYyMjQ0M2U0NmE1NGQ3NTYzYjE3MGQyOTg4ZmU1MDlhOTRlZWVhOTBmMTgxNmI2ZGRhYWExNTVmYmE0ZDI|this invite link>.\n\n*Good luck shipping your first project!*\n Project Unicorn members have contributed to a <{_frontendUrl}/blog|community blog> that provides guidance for building and shipping a project. You can also ask for help on the slack team when you need it.";
            return message;
        }
    }
}