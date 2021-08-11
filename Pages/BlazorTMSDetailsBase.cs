using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using SupportMonitorBlazor.Models;
using SupportMonitorBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace SupportMonitorBlazor.Pages
{
    public class BlazorTMSDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public BlazorTMS BlazorTMS { get; set; } = new BlazorTMS();
        public List<DiskSpace> diskspaceList = new List<DiskSpace>();
        public List<TmsProperties> TmsProps = new List<TmsProperties>();
        [Inject]
        public IBlazorTmsService BlazorTmsService { get; set; }
        [Inject]
        public IDiskSpaceService DiskSpaceService { get; set; }
        [Inject]
        public ITmsPropertiesService TmsPropertiesService { get; set; }
        public bool showModal { get; set; } = false;
        public bool showFolderModal { get; set; } = false;
        private HttpClient client;
    
        public string webAdressToCheckResponse { get; set; }
        private System.Timers.Timer timer;


         public int currentCount = 0;



        public string setFolderValue(int maxSize, int actualSize)
        {
            var tempValue = ((decimal)actualSize / (decimal)maxSize * 100);
            return (Convert.ToInt32(tempValue)).ToString();
        }

        public void openDiskModal()
        {


            showFolderModal = !showFolderModal;
        }

        public string setFolderValuePresent(int maxSize, int actualSize)
        {
            var tempValue = ((decimal)actualSize / (decimal)maxSize * 100);
            return (Convert.ToInt32(tempValue)).ToString() + "%";
        }
        public string usedFolderCapasety(int maxSize, int actualSize)
        {

            var tempValue = ((decimal)actualSize / (decimal)maxSize * 100);
            return (100 - tempValue).ToString() + "%";
        }

        public string setProgressBarColor(int maxSize, int actualSize)
        {


            var tempValue = ((decimal)actualSize / (decimal)maxSize * 100);

            var alertvalue = "";
            if (tempValue <= 60)
            {


                alertvalue = "progress-bar progress-bar-striped bg-success";

            }
            else if (tempValue >= 60 && tempValue <= 80)
            {
                alertvalue = "progress-bar progress-bar-striped bg-warning";
            }
            else if (tempValue > 80)
            {
                alertvalue = "progress-bar progress-bar-striped bg-danger";
            }
            return alertvalue;

        }

     









        protected override async Task OnInitializedAsync()
        {

            client = new HttpClient();
          

            BlazorTMS = await BlazorTmsService.GetTMS(int.Parse(Id));
            TmsProps = (await TmsPropertiesService.GetTmsProperties(int.Parse(Id))).ToList();
            diskspaceList = (await DiskSpaceService.GetTMSDiskspace(int.Parse(Id))).ToList();

            if (TmsProps.Count>0) {
                try
                {
                    var webAdressToCheck = await client.GetAsync(TmsProps[0].Value);//https://web.tdxweb.se/Account/
                    if (webAdressToCheck.IsSuccessStatusCode)
                    {
                        webAdressToCheckResponse =  webAdressToCheck.StatusCode.ToString();
                    }
                    else
                    {
                        webAdressToCheckResponse =  webAdressToCheck.StatusCode.ToString();
                    }
                  }
                catch (Exception e)
                 {

                    webAdressToCheckResponse = "Kan ikke koble til. Serveren er nede :"+ e.Message;
                 }


                client.Dispose();

            timer = new System.Timers.Timer(4000);
            timer.Elapsed += (sender, eventArgs) => OnTimerCallback();
            timer.Start();
            }

            base.OnInitialized();

            


        }



      

        private void OnTimerCallback()
        {
            _ =  InvokeAsync(async () =>
            {
                currentCount++;
                webAdressToCheckResponse = "Laster på nytt";
                await Task.Delay(1000);
                client = new HttpClient();

                if (TmsProps.Count > 0)
                {
                    try
                    {
                        var webAdressToCheck = await client.GetAsync(TmsProps[0].Value);//https://web.tdxweb.se/Account/
                        if (webAdressToCheck.IsSuccessStatusCode)
                        {
                            webAdressToCheckResponse = webAdressToCheck.StatusCode.ToString();

                        }
                        else
                        {
                            webAdressToCheckResponse = webAdressToCheck.StatusCode.ToString();

                        }
                    }
                    catch (Exception e)
                    {

                        webAdressToCheckResponse = "Kan ikke koble til! Serveren er nede :" + e.Message;
                      
                    }

                }
                  
                client.Dispose();

              
                StateHasChanged();
            });
        }

        public void Dispose() => timer?.Dispose();
    }
}

