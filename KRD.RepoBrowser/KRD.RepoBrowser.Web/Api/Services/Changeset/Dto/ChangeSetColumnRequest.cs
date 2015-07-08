using System.Collections.Generic;
using ServiceStack;
//using ServiceStack.ServiceHost;

namespace KRD.RepoBrowser.Web.Api.Services.Changeset.Dto
{
  [Route("/changeset/{columnName}", "GET")]
  public class ChangeSetColumnRequest : IReturn<List<string>>
  {
    public string ColumnName { get; set; }
  }
}