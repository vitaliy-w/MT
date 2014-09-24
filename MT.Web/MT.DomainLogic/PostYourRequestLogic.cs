using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class PostYourRequestLogic
    {
        public void SaveRequest(PostRequest postYourRequest)
        {
            MentorDataContext context = new MentorDataContext();

            if (postYourRequest.Id == 0)
            {
                context.PostYourRequests.Add(postYourRequest);
            }
            else
            {
                PostRequest dbEntry = context.PostYourRequests.Find(postYourRequest.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = postYourRequest.Name;
                    dbEntry.Description = postYourRequest.Description;
                    dbEntry.RequestPostingVisibility = postYourRequest.RequestPostingVisibility;
                    dbEntry.PreferredCandidateLocation = postYourRequest.PreferredCandidateLocation;
                    dbEntry.PostPeriod = postYourRequest.PostPeriod;
                    dbEntry.StartDate = postYourRequest.StartDate;
                }
            }
            context.SaveChanges();
        }
    }
}
