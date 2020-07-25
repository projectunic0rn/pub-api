using Common.AppSettings;

namespace CommunicationAppDomain.ChatMessages
{
    public static class Messages
    {
        private static string _frontendUrl = AppSettings.MainUrl;
        
        public static string OnboardingMessage(string slackId, string signinId, string signinPassword)
        {
            string message = $"Hey <@{slackId}> welcome to the workspace! This is an automated message from <@UBW8QQG86> (aka <https://github.com/roymoran|roymoran> on github), I will follow up with a DM soon. Below is a short checklist of things to do in order to start or join a project.\n\n*1. Introduce yourself :wave:*\n Head over to the intros channel and drop your introduction. Put a little thought into it since we use your introduction to connect you to the right developers and projects. Tip: Once you've introduced yourself you can add emojis to your own introduction to assign yourself tech/languages. \n\n*2. Build something awesome! :computer: :rocket:*\n You can find projects using the `/projects` workspace command. This will show you an active list of projects being worked on in the group. You can also view the <{_frontendUrl}/projects|projects page> for the same information.\n\n*3. Team up! :projectunicorn:*\n Login to the ui with the `/magic-login-link` slack command or visit {_frontendUrl} with the credentials below. Once you're in, visit the <{_frontendUrl}/projects|projects page> and click 'Join'. Once joined you can click on the workspace icon to join the project workspace!\n email: `{signinId}` \n password: `{signinPassword}`\n\n*Starting your own project*\nYou can create a new project through the <{_frontendUrl}/projects|projects page>! New projects are shared with all members through notifications/emails. You can also invite new members to the workspace with <https://join.slack.com/t/project-unic0rn/shared_invite/enQtNzUyNTA1OTgzNzE5LWJmNDYyMjQ0M2U0NmE1NGQ3NTYzYjE3MGQyOTg4ZmU1MDlhOTRlZWVhOTBmMTgxNmI2ZGRhYWExNTVmYmE0ZDI|this invite link>.\n\n*Good luck on your project!*\n";
            return message;
        }

        public static string OnboardingRegisteredMessage(string slackId)
        {
            string message = $"Hey <@{slackId}> welcome to the workspace! This is an automated message from <@UBW8QQG86> (aka <https://github.com/roymoran|roymoran> on github), I will follow up with a DM soon. Below is a short checklist of things to do in order to start or join a project.\n\n*1. Introduce yourself :wave:*\n Head over to the intros channel and drop your introduction. Put a little thought into it since we use your introduction to connect you to the right developers and projects. Tip: Once you've introduced yourself you can add emojis to your own introduction to assign yourself tech/languages. \n\n*2. Build something awesome! :computer: :rocket:*\n You can find projects using the `/projects` workspace command. This will show you an active list of projects being worked on in the group. You can also view the <{_frontendUrl}/projects|projects page> for the same information.\n\n*3. Team up! :projectunicorn:*\n Login to the ui with the `/magic-login-link` slack command or visit {_frontendUrl} with the credentials you registered with. Once you're in, visit the <{_frontendUrl}/projects|projects page> and click 'Join'. Once joined you can click on the workspace icon to join the project workspace!\n\n*Starting your own project*\nYou can create a new project through the <{_frontendUrl}/projects|projects page>! New projects are shared with all members through notifications/emails. You can also invite new members to the workspace with <https://join.slack.com/t/project-unic0rn/shared_invite/enQtNzUyNTA1OTgzNzE5LWJmNDYyMjQ0M2U0NmE1NGQ3NTYzYjE3MGQyOTg4ZmU1MDlhOTRlZWVhOTBmMTgxNmI2ZGRhYWExNTVmYmE0ZDI|this invite link>.\n\n*Good luck on your project!*\n";
            return message;
        }

        public static string OnboardingDm(string slackId)
        {
            string message = $"hey <@{slackId}> thanks for joining - share a quick intro when you get the chance. I'll use the tech mentioned to share some projects/devs you can collab with.";
            return message;
        }

        public static string DeveloperRecommendationsBasedOnSkillsMessage(string slackId)
        {
            string message = $"here's a few devs you can DM based on tech you mentioned. They all joined for similar reasons so don't hesitate to reach out to them and ask if they'd like to collaborate with you.\n";
            return message;
        }

        public static string ProjectRecommendationsBasedOnSkillsMessage(string slackId)
        {
            string message = $"here are some projects you can check out based on tech you mentioned. If you're looking for collaborators to help you on your project or want to start your own you can post it on our UI and I will share it with other devs that join this group. Get to the UI using the slack command `/magic-login-link`.\n\n";
            return message;
        }
    }
}