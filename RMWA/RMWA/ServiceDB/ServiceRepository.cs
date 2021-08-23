using RMWA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Web;

namespace RMWA.ServiceDB
{
    public static class ServiceRepository
    {
        public static void AddTagValue(Models.ResourceWithValue resource)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/ResourceOperationInfo_Kafka/", resource).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //MessageBox.Show("successfully added tag Value");
                    }
                    //else
                        //MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

    }
}