using MontyHallLibrary;
using Xunit;

namespace MontyHallTests
{
    public class SimulationResponseThingyTests
    {
        [Fact]
        public void check_state_of_simulation_response_if_switching()
        {
            // Arrange  
            var simResponseThingy = new SimulationResponseThingy(true);

            // Act  
            var door = simResponseThingy.SwitchToOtherDoor();

            // Assert
            Assert.True(door);
        }
    }
}