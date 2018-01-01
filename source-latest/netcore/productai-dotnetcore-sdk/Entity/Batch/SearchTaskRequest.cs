using System;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class SearchTaskRequest : Core.BaseRequest<SearchTaskResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/tasks?start={1:yyyy-MM-ddTHH:mm:ssZ}&end={2:yyyy-MM-ddTHH:mm:ssZ}", this.Host, this.StartDate, this.EndDate);
            }
        }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SearchTaskRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }

        public SearchTaskRequest(DateTime? start, DateTime? end)
            : this()
        {
            this.StartDate = start;
            this.EndDate = end;
        }
    }
}
