using Common.AppSettings;

namespace CommunicationAppDomain.ChatMessages
{
    public static class Messages
    {
        private static string _frontendUrl = AppSettings.MainUrl;
        private static string _appUrl = AppSettings.AppUrl;
        
        public static string OnboardingMessage(string slackId, string signinId, string signinPassword)
        {
            string message = $"Hey <@{slackId}> welcome to the workspace! This is an automated message from <@UBW8QQG86>, DM on slack if you questions after reading this message or if would like to collaborate on a project you can find me on GitHub https://github.com/roymoran. Below is a short checklist of things to do in order to start or join a project.\n\n*1. Introduce yourself :wave:*\n Head over to the intros channel and drop your introduction. Put a little thought into it since we use your introduction to connect you to the right developers and projects. Tip: Once you've introduced yourself you can add emojis to your own introduction to assign yourself tech/languages of interest. \n\n*2. Build something awesome! :computer: :rocket:*\n You can find projects using the `/projects` workspace command. This will show you an active list of projects being worked on in the group. You can also view the <{_appUrl}/projects|projects page> for the same information.\n\n*3. Team up! :projectunicorn:*\n Login to the ui with the `/magic-login-link` workspace command or visit {_frontendUrl} with the credentials below. Once you're in, visit the <{_appUrl}/projects|projects page> and click 'Join'. Once joined you can click on the workspace icon to join the project workspace!\n email: `{signinId}` \n password: `{signinPassword}`\n\n*Starting your own project*\nYou can create a new project through the <{_appUrl}/projects|projects page>! New projects are shared with all members through notifications/emails. You can also invite new members to the workspace with <https://join.slack.com/t/project-unic0rn/shared_invite/enQtNzUyNTA1OTgzNzE5LWJmNDYyMjQ0M2U0NmE1NGQ3NTYzYjE3MGQyOTg4ZmU1MDlhOTRlZWVhOTBmMTgxNmI2ZGRhYWExNTVmYmE0ZDI|this invite link>.\n\n*Good luck shipping your project!*\n Project Unicorn members have contributed to a <{_frontendUrl}/blog|community blog> that provides guidance for building and shipping software. If you need help ask on the workspace general channel.";
            return message;
        }
    }
}