using SvcLector.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SvcLector.Domain
{
    public class GitHubRankingsDomain: IGitHubRankingsDomain
    {


        private readonly string url = "https://raw.githubusercontent.com/EvanLi/Github-Ranking/master/Data/github-ranking-2022-02-26.csv";

        public GitHubRankingsDomain()
        {
        }

        public ApiResponse GetGitHubRankings(int numItems,string itemName, string sort)
        {
            ApiResponse apiReponse = new ApiResponse();
            List<GitHubRanking> rankings = new List<GitHubRanking>();

            try
            {
                if(numItems > 10)
                {
                    apiReponse.MessageCode = 400;
                    apiReponse.Message = "No se pueden mostrar mas de 10 registros";
                    apiReponse.Response = rankings;

                    return apiReponse;
                }


                WebRequest wrGet;
                wrGet = WebRequest.Create(url);

                Stream rankingListStream;
                rankingListStream = wrGet.GetResponse().GetResponseStream();

                StreamReader streamReader = new StreamReader(rankingListStream);

                string obj = streamReader.ReadToEnd();

                string[] rankinObjects = obj.Split('\n');

                List<GitHubRanking> finalRankings = new List<GitHubRanking>();

                for(int i = 1; i < rankinObjects.Length -1; i++)
                {
                    string rankObj = rankinObjects[i];

                    string[] rankColumns = rankObj.Split(',');

                    finalRankings.Add(new GitHubRanking {
                        Rank = Convert.ToInt32(rankColumns[0]),
                        Item = rankColumns[1],
                        RepoName = rankColumns[2],
                        Stars = rankColumns[3],
                        Forks = rankColumns[4],
                        Language = rankColumns[5],
                        RepoUrl = rankColumns[6],
                        UserName = rankColumns[7],
                        Issues = rankColumns[8],
                        LastCommit = rankColumns[9],
                        Description = rankColumns[10]
                    });

                }

                rankings = (sort == "asc" ?  (from r in finalRankings
                            where (itemName == string.Empty || r.Item == itemName)
                            orderby r.Rank ascending
                            select r).Take(numItems).ToList() :

                            (from r in finalRankings
                             where (itemName == string.Empty || r.Item == itemName)
                             orderby r.Rank descending
                             select r).Take(numItems).ToList()); 


                if(rankings.Count() > 0)
                {
                    apiReponse.MessageCode = 200;
                    apiReponse.Response = rankings;
                }
                else
                {
                    apiReponse.MessageCode = 404;
                    apiReponse.Message = "No se encontraron Datos";
                    apiReponse.Response = rankings;
                }

                return apiReponse;
            }
            catch (Exception ex)
            {
                apiReponse.MessageCode = 500;
                apiReponse.Message = "Ocurrio un error al al generar la información: Detalle: " + ex.Message;
                apiReponse.Response = rankings;

                return apiReponse;
            }
          
        }

    }
}
