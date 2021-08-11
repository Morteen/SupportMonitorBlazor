using Microsoft.AspNetCore.Components;
using SupportMonitorBlazor.Models;
using SupportMonitorBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Pages
{
    public class TestUpdatedateBase : ComponentBase
    {

        [Inject]
        public IDiskSpaceService DiskSpaceService { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }
      

        public IEnumerable<DiskSpace> DiskspaceList { get; set; }
        public List<DiskSpace> DiskSpaceProps = new List<DiskSpace>();
        protected override async Task OnInitializedAsync()
        {

            DiskSpaceProps = (await DiskSpaceService.GetAllDiskSpace()).ToList();


         



        }

       
     

        public async Task TestUpdateDB()
        {
           var result = await DiskSpaceService.UpdateDiskSpace( new DiskSpace { Id=1,TmsId = 2, Name = "E", Type = "Local TEST Disk", FreespacePercentMinimum = 5, FrespaceMinimumBytes = 5000, Actualsize = 444, MaxSize = 10000 });
        }

        private static async Task UpdateDiskSpace(DiskSpace space)
        {




            ///Dette er vanlig HTTP client 

            using (var client = new HttpClient())
            {


                //client.BaseAddress = new Uri("https://localhost:44388/api/DiskSpace/1");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", "xyz");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                HttpResponseMessage response;
                Console.WriteLine("Sjekker hva som er i fred med å sendes:  Space id:" + space.Id + " Space name: " + space.Name + " Status : " + space.Actualsize);


                Console.WriteLine("Dette er Space objectet " + space.Id + " - " + space.TmsId + " - " + space.Actualsize + "  Type:" + space.Type);
               // var content = new StringContent(JsonConvert.SerializeObject(space), Encoding.UTF8, "application/json");
                //Console.WriteLine(JsonConvert.SerializeObject(new DiskSpace { TmsId = 2, Name = "E", Type = "Local TEST Disk", FreespacePercentMinimum = 5, FrespaceMinimumBytes = 5000, Actualsize = 444, MaxSize = 10000 }));

                response = await client.PutAsJsonAsync("https://localhost:44388/api/DiskSpace", space);
                //response = await client.PutAsync("https://localhost:44388/api/DiskSpace/1", content);

                

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Denne mappen har  endret status: " + space.Name + "  Status:" + space.Actualsize);
                }
                else { Console.WriteLine("Det er noe galt: " + response.ReasonPhrase); }
                client.Dispose();
            }
        }


    }
}
