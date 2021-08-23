using RMWA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace RMWA.ServiceDB
{
    public static class dbSaver
    {
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ToString(); 

        public static void AddResource(FormCollection data)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                List<TypeModel> resList = ValueService.GetTypeInfo();
                long typeId = Convert.ToInt64(data[2]);
                string typeName = resList.Where(x => x.TypeId == typeId).Select(x => x.TypeName).FirstOrDefault();
                long resId = -999;
                if(!String.IsNullOrEmpty(data[3]))
                {
                    resId = Convert.ToInt64(data[3]);
                }
                string resName = data[4];
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[ResourceTable](Id,Name,Type,TypeId,CreationDate) " +
                        "Values(" + resId + ",'" + resName + "','" + typeName + "'," + typeId + ",'" + DateTime.Now + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void AddTagValue(FormCollection data)
        {
            ResourceWithValue resVal = new ResourceWithValue();
            resVal.ResourceId = -999;
            if(!String.IsNullOrEmpty(data[2]))
            {
                resVal.ResourceId = Convert.ToInt64(data[2]);
            }
            resVal.TagId = -999;
            if(!String.IsNullOrEmpty(data[3]))
            {
                resVal.TagName = data[3];
            }

            List < TagOnFetchData > resFetchList = ValueService.GetTagRegDetails();
            List<TagOnFetchData> tagList = ValueService.GetTagNameDetails();
            resVal.TagId = resFetchList.Where(x => x.TagResourceId == resVal.ResourceId && x.TagName == resVal.TagName).Select(x => x.TagId).FirstOrDefault();
            resVal.TagUOM = resFetchList.Where(x => x.TagId == resVal.TagId && x.TagResourceId == resVal.ResourceId).Select(x => x.TagUOM).FirstOrDefault();
            resVal.TagValue = data[4];
            resVal.TagCreationDate = DateTime.Now;

            ServiceRepository.AddTagValue(resVal);
        }

        public static void CreateTag(FormCollection data)
        {
            long resId = Convert.ToInt64(data[2]);
            string resName = ValueService.GetResourceDetails().Where(x => x.ResourceId == resId).Select(x => x.ResourceName).FirstOrDefault();

            String tagName = data[3];          
            String tagUOM = ValueService.GetTagNameDetails().Where(x => x.TagName == tagName).Select(x => x.TagUOM).FirstOrDefault();

            long typeId = ValueService.GetResourceDetails().Where(x => x.ResourceId == resId).Select(x => x.TypeID).FirstOrDefault();
            string typeName = ValueService.GetResourceDetails().Where(x => x.ResourceId == resId).Select(x => x.TypeName).FirstOrDefault();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[ResourceAndTagRegistrationTable](TypeName,TypeId,TagName,ResourceId,TagUOM,ResourceName) " +
                        "Values('" + typeName + "'," + typeId + ",'" + tagName + "'," + resId + ",'"
                        + tagUOM + "','" + resName + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void CreateResourceType(FormCollection data)
        {
            int resTypeId = -999;
            if(!String.IsNullOrEmpty(data[2]))
            {
                resTypeId = Convert.ToInt32(data[2]);
            }
            string resTypeName = data[3];
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[TypeTable](Id,Name) Values(" + resTypeId + ",'" + resTypeName + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void CreateStatus(FormCollection data)
        {
            int statusId = -999;
            if(!String.IsNullOrEmpty(data[2]))
            {
                statusId = Convert.ToInt32(data[2]);
            }
            string statusName = data[3];

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[StatusTable](Id,Name) Values(" + statusId + ",'" + statusName + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void CreateSystemTag(FormCollection data)
        {
            string tagName = data[2];
            string tagUOM = data[3];
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[TagNamesTable](TagName,TagUOM) " +
                        "Values('" + tagName + "','" + tagUOM + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}