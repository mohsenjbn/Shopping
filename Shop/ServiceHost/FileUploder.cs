﻿using _0_Framework.Application;
using _01_framework.Application;
using System;

namespace ServiceHost
{
    public class FileUploder : IFileUploder
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploder(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directorypath = $"{_webHostEnvironment.WebRootPath}//UpdolerFile//{path}";
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }
            var FileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filepath = $"{directorypath}//{FileName}";

            using var output = File.Create(filepath);
            file.CopyTo(output);

            return $"{path}/{FileName}";

        }
    }
}

