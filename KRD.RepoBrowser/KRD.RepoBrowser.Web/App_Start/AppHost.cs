using System.Configuration;
using System.Web.Mvc;

using KRD.RepoBrowser.Data.Query;
using KRD.RepoBrowser.Data.Query.Interfaces;
using KRD.RepoBrowser.Web.Api.Services.Changeset;

using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

[assembly: WebActivator.PreApplicationStartMethod(typeof(KRD.RepoBrowser.Web.App_Start.AppHost), "Start")]

namespace KRD.RepoBrowser.Web.App_Start
{
  public class AppHost
    : AppHostBase
  {
    public AppHost()
      : base("KRD.RepoBrowser ASP.NET Host", typeof(ChangesetService).Assembly)
    {
    }

    public static void Start()
    {
      new AppHost().Init();
    }

    public override void Configure(Funq.Container container)
    {
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = JsonDateHandler.ISO8601;

      RegisterIoC(container);

      ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
    }

    private void RegisterIoC(Funq.Container container)
    {
      var connectionString = ConfigurationManager.ConnectionStrings["SourceMiner"].ConnectionString;

      container.Register<IDbConnectionFactory>(c =>
                                               new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider));

      container.RegisterAs<OrmLiteChangesetQuery, IChangesetQuery>();

      container.Register<ICacheClient>(new MemoryCacheClient());
    }
  }
}