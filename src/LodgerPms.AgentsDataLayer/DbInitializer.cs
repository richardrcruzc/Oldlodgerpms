
using LodgerPms.Domain.Agents;
using System.Linq;

namespace LodgerPms.AgentsDataLayer
{
     
    public class DbInitializer
    {
        public static void Initialize(AgentsContext cntxt)
        {
            if (!cntxt.Agents.Any())
            {
                var a = Agent.New("Agent 1","Term",89.99M);
                cntxt.Agents.AddAsync(a);

            }
        }
    }
            }
