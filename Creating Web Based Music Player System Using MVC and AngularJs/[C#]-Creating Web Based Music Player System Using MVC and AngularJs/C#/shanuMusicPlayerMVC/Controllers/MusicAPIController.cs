using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shanuMusicPlayerMVC.Controllers
{
    public class MusicAPIController : ApiController
    {
        MusicPlayerDBEntities objapi = new MusicPlayerDBEntities();

        // To select Album Details
        [HttpGet]
        public IEnumerable<USP_AlbumMaster_Select_Result> getAlbums(string AlbumName)
        {
            if (AlbumName == null)
                AlbumName = "";
            return objapi.USP_AlbumMaster_Select(AlbumName).AsEnumerable();
        }

        // To insertKIDSLEARN
        [HttpGet]
        public IEnumerable<string> insertAlbum(string AlbumName, string ImageName)
        {
            if (AlbumName == null)
                AlbumName = "";

            if (ImageName == null)
                ImageName = "";

            return objapi.USP_Album_Insert(AlbumName, ImageName).AsEnumerable();

        }



        // to Search all Music Album Details
        [HttpGet]
        public IEnumerable<USP_MusicAlbum_SelectALL_Result> getMusicSelectALL(string AlbumName)
        {
            if (AlbumName == null)
                AlbumName = "";

            return objapi.USP_MusicAlbum_SelectALL(AlbumName).AsEnumerable();
        }

        // To insert Music Details
        [HttpGet]
        public IEnumerable<string> insertMusic(string SingerName, string AlbumName, string MusicFileName, string Description)
        {
            if (SingerName == null)
                SingerName = "";

            if (MusicFileName == null)
                MusicFileName = "";

            if (AlbumName == null)
                AlbumName = "";

            if (Description == null)
                Description = "";

            return objapi.USP_MusicAlbum_Insert(SingerName, AlbumName, MusicFileName, Description).AsEnumerable();

        }

        // To Update Music Details
        [HttpGet]
        public IEnumerable<string> updateMusic(string musicID, string SingerName, string AlbumName, string MusicFileName, string Description)
        {
            if (musicID == null)
                musicID = "0";

            if (SingerName == null)
                SingerName = "";

            if (MusicFileName == null)
                MusicFileName = "";

            if (AlbumName == null)
                AlbumName = "";

            if (Description == null)
                Description = "";

            return objapi.USP_MusicAlbum_Update(musicID, SingerName, AlbumName, MusicFileName, Description).AsEnumerable();

        }



        // To Delete Music Details
        [HttpGet]
        public IEnumerable<string> deleteMusic(string musicID)
        {
            if (musicID == null)
                musicID = "0";


            return objapi.USP_MusicAlbum_Delete(musicID).AsEnumerable();

        }
    }
}
