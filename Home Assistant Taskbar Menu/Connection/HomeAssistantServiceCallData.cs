﻿using System;
using System.Collections.Generic;
using Home_Assistant_Taskbar_Menu.Entities;
using Newtonsoft.Json;

namespace Home_Assistant_Taskbar_Menu.Connection
{
    public class HomeAssistantServiceCallData
    {
        [JsonProperty("domain")] public string Domain { get; }

        [JsonProperty("service")] public string Service { get; }

        [JsonProperty("service_data")] public Dictionary<string, object> ServiceData { get; }

        public HomeAssistantServiceCallData(string domain, string service, Dictionary<string, object> serviceData)
        {
            Domain = domain;
            Service = service;
            ServiceData = serviceData;
        }

        public HomeAssistantServiceCallData(string service, Entity stateObject,
            params Tuple<string, object>[] data)
        {
            var serviceData = new Dictionary<string, object>
            {
                {"entity_id", stateObject.EntityId}
            };
            foreach (Tuple<string, object> tuple in data)
            {
                string parameter = tuple.Item1;
                object value = tuple.Item2;
                serviceData[parameter] = value;
            }

            Domain = stateObject.Domain();
            Service = service;
            ServiceData = serviceData;
        }
    }
}