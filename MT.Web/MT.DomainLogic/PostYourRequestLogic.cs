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
        public void SaveRequest(PostYourRequest postYourRequest)
        {
            MentorDataContext context = new MentorDataContext();

            if (postYourRequest.RequestId == 0)
            {
                context.PostYourRequests.Add(postYourRequest);
            }
            else
            {
                PostYourRequest dbEntry = context.PostYourRequests.Find(postYourRequest.RequestId);
                if (dbEntry != null)
                {
                    dbEntry.Name = postYourRequest.Name;
                    dbEntry.Description = postYourRequest.Description;
                    dbEntry.RequestPostingVisibility = postYourRequest.RequestPostingVisibility;
                    dbEntry.PreferredCandidateLocation = postYourRequest.PreferredCandidateLocation;
                    dbEntry.PostThisRequestFor = postYourRequest.PostThisRequestFor;
                    dbEntry.ProposedStartDate = postYourRequest.ProposedStartDate;
                }
            }
            context.SaveChanges();
        }
    }
}
