using App1.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1.Plugin
{
    class SaveToken
    {
        public async Task<Credential> LoadAccessTokenFromFile()
        {
            try
            {
                // read token file.
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile storageFile = await storageFolder.GetFileAsync("milt.txt");
                var fileContent = await FileIO.ReadTextAsync(storageFile);
                var credential = JsonConvert.DeserializeObject<Credential>(fileContent);
                return credential;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task WriteTokenToFile(string content)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //// lấy ra file cần làm việc từ trong thư mục đó.
            StorageFile storageFile = await storageFolder.CreateFileAsync("milt.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, content);
        }
    }
}
