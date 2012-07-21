using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Email.Template.List.Entities;

namespace ThreeBytes.Email.Template.List.Frontend.Models
{
    public class PagedEmailTemplateEmailViewModel
    {
        public IPagedResult<EmailTemplateListTemplate> PagedResult { get; set; }
        public IMostRecentResult<EmailTemplateListTemplate> MostRecentResult { get; set; }

        public PagedEmailTemplateEmailViewModel(IPagedResult<EmailTemplateListTemplate> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedEmailTemplateEmailViewModel(IPagedResult<EmailTemplateListTemplate> pagedResult, IMostRecentResult<EmailTemplateListTemplate> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<EmailTemplateListTemplate>(new List<EmailTemplateListTemplate>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
