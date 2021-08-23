using RMWA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RMWA.ServiceDB
{
    /// <summary>
    /// Get Data For the application - dropdownList
    /// </summary>
    public static class ValueService
    {
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ToString();

        #region Get Type Information
        public static List<Models.TypeModel> GetTypeInfo()
        {
            List<Models.TypeModel> typeList = new List<Models.TypeModel>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from [RM_K_DB_V2.1].[dbo].[TypeTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            typeList.Add(
                                new Models.TypeModel
                                {
                                    TypeId = Convert.ToInt32(row["Id"]),
                                    TypeName = Convert.ToString(row["Name"])
                                });
                        }
                    }
                }
                con.Close();
            }
            return typeList;
        }
        #endregion

        #region Get Resource details
        public static List<ResourceModelOnFetchData> GetResourceDetails()
        {
            List<ResourceModelOnFetchData> resourceList = new List<ResourceModelOnFetchData>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select CONCAT(Id, ':- ', Name, ' :(', Type, ')') as ResourceDisplayName, Name ResourceName, Id as ResourceId, Type as TypeName, TypeId from [RM_K_DB_V2.1].[dbo].[ResourceTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            resourceList.Add(
                                new ResourceModelOnFetchData
                                {
                                    ResourceId = Convert.ToInt64(row["ResourceId"]),
                                    ResourceName = Convert.ToString(row["ResourceName"]),
                                    ResourceDisplayName = Convert.ToString(row["ResourceDisplayName"]),
                                    TypeName = Convert.ToString(row["TypeName"]),
                                    TypeID = Convert.ToInt32(row["TypeId"])
                                }
                                );
                        }
                    }
                }
                con.Close();
            }
            return resourceList;
        }
        #endregion

        #region GetTagNamesDetails
        public static List<TagOnFetchData> GetTagNameDetails()
        {
            List<TagOnFetchData> tagNameList = new List<TagOnFetchData>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select TagName,TagUOM from [RM_K_DB_V2.1].[dbo].[TagNamesTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            tagNameList.Add(
                                new TagOnFetchData
                                {

                                    TagName = Convert.ToString(row["TagName"]),
                                    TagUOM = Convert.ToString(row["TagUOM"])
                                }
                                );
                        }
                    }
                }
                con.Close();
            }
            return tagNameList;
        }
        #endregion

        #region GetTagNamesDetails
        public static List<TagOnFetchData> GetTagRegDetails()
        {
            List<TagOnFetchData> tagNameList = new List<TagOnFetchData>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select TagName,TagUOM,TagId,ResourceId from [RM_K_DB_V2.1].[dbo].[ResourceAndTagRegistrationTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            tagNameList.Add(
                                new TagOnFetchData
                                {

                                    TagName = Convert.ToString(row["TagName"]),
                                    TagUOM = Convert.ToString(row["TagUOM"]),
                                    TagId = Convert.ToInt64(row["TagId"]),
                                    TagResourceId = Convert.ToInt64(row["ResourceId"])
                                }
                                );
                        }
                    }
                }
                con.Close();
            }
            return tagNameList;
        }
        #endregion
    }
}