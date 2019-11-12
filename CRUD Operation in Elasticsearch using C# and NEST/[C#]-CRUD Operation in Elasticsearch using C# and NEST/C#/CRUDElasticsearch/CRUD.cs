using System;
using System.Data;

namespace CRUDElasticsearch
{
    class CRUD
    {
        #region Get document info based on the ID

        public static Tuple<string, string, string, string> getDocument(string searchID)
        {
            string id = "";
            string name = "";
            string originalVoiceActor = "";
            string animatedDebut = "";

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                .Index("disney")
                .Type("character")              
                .Query(q=>q.Term(t=>t.Field("_id").Value(searchID)))); //Search based in _id                

            //Assigining value to their controller
            foreach (var hit in response.Hits)
            {
                id = hit.Id.ToString();// Source.id.ToString();
                name = hit.Source.name.ToString();
                originalVoiceActor = hit.Source.original_voice_actor.ToString();
                animatedDebut = hit.Source.animated_debut.ToString();
            }

            return Tuple.Create(id, name, originalVoiceActor, animatedDebut);
        }

        #endregion Get document info based on the ID

        #region Insert document with on ID

        public static bool insertDocument(string searchID, string tbxname, string tbxOriginalVoiceActor, string tbxAnimatedDebut)
        {
            bool status;

            var myJson = new 
            {
                name = tbxname,
                original_voice_actor = tbxOriginalVoiceActor,
                animated_debut = tbxAnimatedDebut
            };

            var response = ConnectionToES.EsClient().Index(myJson, i => i
                .Index("disney")
                .Type("character")
                .Id(searchID)
                .Refresh());

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        #endregion Insert document with on ID

        #region Get all document from Elasticsearch

        public static DataTable getAllDocument()
        {
            DataTable dataTable = new DataTable("character");
            dataTable.Columns.Add("ID", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Original Voice Actor", typeof(string));
            dataTable.Columns.Add("Animated Debut", typeof(string));

            var response = ConnectionToES.EsClient().Search<DocumentAttributes>(s => s
                .Index("disney")
                .Type("character") 
                .From(0)
                .Size(1000)                
                .Query(q => q.MatchAll()));

            foreach (var hit in response.Hits)
            {
                dataTable.Rows.Add(hit.Id.ToString(), hit.Source.name.ToString(), hit.Source.original_voice_actor.ToString(), hit.Source.animated_debut.ToString());
            }

            return dataTable;
        }

        #endregion Get all document from Elasticsearch

        #region Update document based on ID

        ///Updating a Document can be done in trhee way
        ///1. Update by Partial Document
        ///2. Update by Index Query
        ///3. Update by Script
        ///Here we demonstrated Update by Partial Document and  Update by Index Query. User can choose any of these from below.
        ///Just comment one part and uncomment another.

        public static bool updateDocument(string searchID, string tbxname, string tbxOriginalVoiceActor, string tbxAnimatedDebut)
        {            
            bool status;

            //Update by Partial Document
            var response = ConnectionToES.EsClient().Update<DocumentAttributes, UpdateDocumentAttributes>(searchID, d => d
                .Index("disney")
                .Type("character")
                .Doc(new UpdateDocumentAttributes
                {
                    name = tbxname,
                    original_voice_actor = tbxOriginalVoiceActor,
                    animated_debut = tbxAnimatedDebut
                })); 
            //End of Update by Partial Document

            //Update by Index Query
            /*var myJson = new 
            {
                name = tbxname,
                original_voice_actor = tbxOriginalVoiceActor,
                animated_debut = tbxAnimatedDebut
            };

            var response = ConnectionToES.EsClient().Index(myJson, i => i
                .Index("disney")
                .Type("character")
                .Id(searchID)
                .Refresh());*/
            //End of Update by Index Query

            if(response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        #endregion Update document based on ID

        #region Delete Document based on ID

        public static bool deleteDocument(string searchID)
        {
            bool status;

            var response = ConnectionToES.EsClient().Delete<DocumentAttributes>(searchID, d => d
                .Index("disney")
                .Type("character"));

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        #endregion Delete document based on ID
    }
}
