﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public class JsonFileService<T> : IJsonFileService<T> where T : class
    {

        public IWebHostEnvironment WebHostEnvironment { get;}

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName 
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", typeof(T).Name + "s.json"); }
        }

        public IEnumerable<T> GetJsonObjects()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveJsonObjects(List<T> objects)
        {
            using (var jsonFileWriter = File.Create(JsonFileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<T[]>(jsonWriter, objects.ToArray());
            }
        }
    }
}
