using System;
using Xunit;

namespace CommunicationAppDomain.Tests.Unit
{
    public class EventHandlerTests
    {
        [Fact]
        public void ProcessReactionAddedEvent_TechExists_FailsToPersist()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionAddedEvent_TechDoesntExist_Persists()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionAddedEvent_ByNonPrivilegedMember_FailsToPersist()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionAddedEvent_ByPrivilegedMember_Persists()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionRemovedEvent_ByNonPrivilegedMember_FailsToPersist()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionRemovedEvent_ByPrivilegedMemberButRemainingPrivilegedMembersOrOwner_FailsToPersist()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void ProcessReactionRemovedEvent_ByPrivilegedMemberNoRemainingPrivilegedMembersOrOwner_Persist()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
