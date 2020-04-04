using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;

namespace Reminder.Storage.WebApi.Client
{
    public class ReminderStorageWebApiClient : IReminderStorage
    {
        private HttpClient _httpClient;
        private string _baseWebApiUrl;

        public ReminderStorageWebApiClient(string baseWebApiUrl)
        {
            _httpClient = new HttpClient();
            _baseWebApiUrl = baseWebApiUrl;
        }

        public int Count => throw new NotImplementedException();

        public Guid Add(ReminderItemRestricted reminder)
        {


            ReminderItemCreateModel reminderItemCreateModel = new ReminderItemCreateModel(reminder);

            string content = JsonConvert.SerializeObject(reminderItemCreateModel);


            var httpResponseMessage = CallWebApi(HttpMethod.Post, null, content);
            if (httpResponseMessage.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception(
                    $"Error: {httpResponseMessage.StatusCode}, " +
                    $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }
            string resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ReminderItemGetModel reminderItemGetModel =
                JsonConvert.DeserializeObject<ReminderItemGetModel>(resultContent);
            return reminderItemGetModel.Id;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public ReminderItem Get(Guid id)
        {
            var httpResponseMessage = CallWebApi(HttpMethod.Get, "/"+id.ToString());

            if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"Error: {httpResponseMessage.StatusCode}, " +
                    $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }

            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ReminderItemGetModel reminderItemGetModel =
                JsonConvert.DeserializeObject<ReminderItemGetModel>(content);

            return reminderItemGetModel.ToReminderItem();
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            var httpResponseMessage = CallWebApi(HttpMethod.Get, $"?count={count}&startPostion={startPostion}");

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"Error: {httpResponseMessage.StatusCode}, " +
                    $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }

            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            List<ReminderItemGetModel> reminderItemGetModelList =
                JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

            List<ReminderItem> reminderItemList = new List<ReminderItem>();
            foreach(ReminderItemGetModel x in reminderItemGetModelList)
            {
                reminderItemList.Add(x.ToReminderItem());
            }

            return reminderItemList;
        }
        public List<ReminderItem> Get(ReminderItemStatus status, int count = 0, int startPostion = 0)
        {
            var httpResponseMessage = CallWebApi(HttpMethod.Get, $"?status={status}&count={count}&startPostion={startPostion}");

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"Error: {httpResponseMessage.StatusCode}, " +
                    $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }

            string content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            List<ReminderItemGetModel> reminderItemGetModelList =
                JsonConvert.DeserializeObject<List<ReminderItemGetModel>>(content);

            List<ReminderItem> reminderItemList = new List<ReminderItem>();
            foreach (ReminderItemGetModel x in reminderItemGetModelList)
            {
                reminderItemList.Add(x.ToReminderItem());
            }

            return reminderItemList;
        }
                

        public bool Remove(Guid id)
        {
            var httpResponseMessage = CallWebApi(HttpMethod.Delete, $"?id={id}");
            if ((httpResponseMessage.StatusCode != HttpStatusCode.OK)&&(httpResponseMessage.StatusCode != HttpStatusCode.NotFound))
            {
                throw new Exception(
                        $"Error: {httpResponseMessage.StatusCode}, " +
                        $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
                return false;
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            foreach(Guid id in ids)
            {
                var httpResponseMessage = CallWebApi(HttpMethod.Put, $"?status={status}&id={id}");
                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(
                        $"Error: {httpResponseMessage.StatusCode}, " +
                        $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
                }
            }            
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            var httpResponseMessage = CallWebApi(HttpMethod.Put, $"?status={status}&id={id}");
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(
                    $"Error: {httpResponseMessage.StatusCode}, " +
                    $"Content: {httpResponseMessage.Content.ReadAsStringAsync().Result}");
            }
        }

        private HttpResponseMessage CallWebApi(HttpMethod method, string relativeUrl, string content = null)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                method,
                _baseWebApiUrl + relativeUrl ?? string.Empty);
            if (content != null)
            {
                httpRequestMessage.Content = new StringContent(
                content,
                Encoding.UTF8,
                "application/json");
            }

            return _httpClient.SendAsync(httpRequestMessage).Result;
        }
    }
}
