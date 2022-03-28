using SvcLector.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvcLector.Domain
{
    public interface IGitHubRankingsDomain
    {
        ApiResponse GetGitHubRankings(int numItems, string itemName, string sort);

    }
}
