using Microsoft.AspNetCore.Components;
using SupportMonitorBlazor.Models;
using SupportMonitorBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Pages
{
    public class TmsListBase : ComponentBase
    {
        [Inject]
        public IBlazorTmsService BlazorTmsService { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ITmsPropertiesService TmsPropertiesService { get; set; }

        public IEnumerable<BlazorTMS> BlazorTmsList { get; set; }
        public IEnumerable<BlazorTMS> BlazorTmsSortedList { get; set; }
        public IEnumerable<BlazorTMS> TransFleetList { get; set; }
        public IEnumerable<BlazorTMS> TdxlogList { get; set; }
        string url = "/BlazorTMSDetails/";

        private System.Timers.Timer timer;
       
        public List<TmsProperties> TmsProps = new List<TmsProperties>();

        private HttpClient  client = new HttpClient();
        protected override async Task OnInitializedAsync()
        {
        
            TmsProps = (await TmsPropertiesService.GetAllTmsProperties()).ToList();


            BlazorTmsList = (await BlazorTmsService.GetBlazorTms()).ToList();
            BlazorTmsSortedList = BlazorTmsList.OrderByDescending(tms => tms.CriticalErrors);
            TransFleetList = BlazorTmsList.Where(tms => tms.TmsCategory == "TransFleet");
            TdxlogList = BlazorTmsList.Where(tms => tms.TmsCategory == "Tdxlog");

            foreach (var tms in BlazorTmsSortedList)
            {
                setWebValues(tms,TmsProps);
            }

            timer = new System.Timers.Timer(4000);
            timer.Elapsed += (sender, eventArgs) => OnTimerCallback();
            timer.Start();



        }


        public void NavtoPage(int id)
        {

            NavManager.NavigateTo(url + id);
        }
        public string SetAlertBackround(BlazorTMS tms)
        {
            if (tms.CriticalErrors > 0)
            {
                return "alertColor";
            }
            else return null;
        }
        public string SetStatusColor(BlazorTMS tms)
        {
            if (tms.CriticalErrors > 0)
            {
                return "alertColor";
            }
            else return "OkColor";
        }
        public string SetStatusText(BlazorTMS tms)
        {
            if (tms.CriticalErrors > 0)
            {
                return "System down !";
            }
            else return "System running";
        }



        public async void setWebValues(BlazorTMS tms, List<TmsProperties> tmsprop)
        {
            client = new HttpClient();
            List<TmsProperties> templist;
             templist = (await TmsPropertiesService.GetTmsProperties(tms.TmsId)).ToList();
            foreach (var tmsp in templist)
            {
                if (tmsp!=null && tmsp.TmsId == tms.TmsId)
                {
                  
                    try
                    {
                        var webAdressToCheck = await client.GetAsync(tmsp.Value);//https://web.tdxweb.se/Account/
                        if (webAdressToCheck.IsSuccessStatusCode)
                        {
                            tms.CriticalErrors = 0;

                            SetStatusText(tms);
                            SetStatusColor(tms);
                            SetAlertBackround(tms);
                        }
                        else
                        {
                            tms.CriticalErrors++;
                            
                            SetStatusText(tms);
                            SetStatusColor(tms);
                            SetAlertBackround(tms);
                        }
                    }
                    catch (Exception e)
                    {

                        tms.CriticalErrors++;
                        SetStatusText(tms);
                        SetStatusColor(tms);
                        SetAlertBackround(tms);
                    }

                    
                  

            };

            }
            //client.Dispose();


        }



        private void OnTimerCallback()
        {
            _ = InvokeAsync(async () =>
            {
               ;
              
            

                foreach (var tms2 in BlazorTmsSortedList)
                {
                    var templiste  = (await TmsPropertiesService.GetTmsProperties(tms2.TmsId)).ToList();//TmsProps.Where(t => t.TmsId == 2).ToList();

                    foreach (var tmsp in templiste)
                        {
                        if (tmsp!=null && tmsp.TmsId == tms2.TmsId)
                        {

                            try
                            {
                                var webAdressToCheck = await client.GetAsync(tmsp.Value);//https://web.tdxweb.se/Account/
                                if (webAdressToCheck.IsSuccessStatusCode)
                                {

                                    tms2.CriticalErrors = 0;

                                    SetStatusText(tms2);
                                    SetStatusColor(tms2);
                                    SetAlertBackround(tms2);
                                }
                                else
                                {
                                    tms2.CriticalErrors++;
                               
                                   SetStatusText(tms2);
                                    SetStatusColor(tms2);
                                    SetAlertBackround(tms2);
                                }
                            }
                            catch (Exception e)
                            {

                                tms2.CriticalErrors++;
                              
                                SetStatusText(tms2);
                                SetStatusColor(tms2);
                                SetAlertBackround(tms2);
                            }
                            

                           

                        };

                    }

                }
               // client.Dispose();
                StateHasChanged();
            });
        }

        public void Dispose() => timer?.Dispose();
        public void Dispose2() => client?.Dispose();
    }
}
