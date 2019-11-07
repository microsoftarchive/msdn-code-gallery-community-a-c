using Microsoft.OData.Edm;
using ODataV4Sample.Models;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataV4Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute(
                "ODataRoute",
                "odata",
                GetEdmModel());
        }

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            // 名前空間の設定
            builder.Namespace = typeof(WebApiConfig).Namespace;

            // エンテティの登録
            builder.EntitySet<Person>("People");

            // 指定した範囲の年齢の分析をする関数
            // Person全体にかかるためコレクションに対する関数として定義する
            var analyzeFunction = builder.EntityType<Person>()
                .Collection
                .Function("Analyze")
                .Returns<AnalyzeResult>();
            analyzeFunction.Parameter<int>("skip");
            analyzeFunction.Parameter<int>("top");

            // 指定した範囲の人を全員加齢させるアクション
            // Person全体にかかるためコレクションに対するアクションとして定義する
            var ageAction = builder.EntityType<Person>()
                .Collection
                .Action("Age");
            ageAction.Parameter<AgeParameter>("p");

            return builder.GetEdmModel();
        }
    }
}
