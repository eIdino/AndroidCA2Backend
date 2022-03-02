using Microsoft.AspNetCore.Mvc;

namespace AndroidCA2Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Games> repos = new()
        {
            new DockerHub() { Username = "jdoe", Repo = "helloworld", Tag = "latest", OSystem = "linux", Size = 20 },
            new DockerHub() { Username = "jdoe", Repo = "helloworld", Tag = "v1", OSystem = "linux", Size = 50 },
            new DockerHub() { Username = "bdo", Repo = "helloworld2", Tag = "latest", OSystem = "linux", Size = 25 },
            new DockerHub() { Username = "senz", Repo = "myrepo", Tag = "latest", OSystem = "linux", Size = 100 },
        };
    }
}