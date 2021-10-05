﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Covid19Radar.Common;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Covid19Radar.Repository
{
    public interface IServerConfigurationRepository
    {
        public string[] Regions { get; set; }

        public string UserRegisterApiEndpoint { get; set; }

        public string DiagnosisKeyRegisterApiBaseEndpoint { get; set; }

        public virtual IList<string> DiagnosisKeyRegisterApiUrls
        {
            get
            {
                return Regions
                    .Select(region => DiagnosisKeyRegisterApiBaseEndpoint.Replace(ServerConfiguration.PLACEHOLDER_REGION, region))
                    .Where(url => url != null)
                    .Distinct()
                    .ToList();
            }
        }

        public string DiagnosisKeyListProvideServerBaseEndpoint { get; set; }

        public virtual string GetDiagnosisKeyListProvideServerUrl(string region)
            => DiagnosisKeyListProvideServerBaseEndpoint.Replace(ServerConfiguration.PLACEHOLDER_REGION, region);

        public virtual IList<string> DiagnosisKeyListProvideServerUrls
        {
            get
            {
                return Regions
                    .Select(region => DiagnosisKeyListProvideServerBaseEndpoint.Replace(ServerConfiguration.PLACEHOLDER_REGION, region))
                    .Where(url => url != null)
                    .Distinct()
                    .ToList();
            }
        }

        public string InquiryLogApiEndpoint { get; set; }

        public string? ExposureDataCollectServerBaseEndpoint { get; set; }

        public virtual IList<string> ExposureDataCollectServerUrls
        {
            get
            {
                return Regions
                    .Select(region => ExposureDataCollectServerBaseEndpoint?.Replace(ServerConfiguration.PLACEHOLDER_REGION, region))
                    .Where(url => url != null)
                    .Distinct()
                    .ToList();
            }
        }

        public Task SaveAsync();

        public Task LoadAsync();
    }

    public class DebugServerConfigurationRepository : IServerConfigurationRepository
    {
        private const string FILE_NAME = "server_configuration.json";
        private const string CONFIGURATION_DIR = "configuration";

        private readonly string _configurationDir;
        private readonly string _serverConfigurationPath;

        private ServerConfiguration _serverConfiguration;

        public DebugServerConfigurationRepository()
        {
            _configurationDir = Path.Combine(FileSystem.AppDataDirectory, CONFIGURATION_DIR);
            if (!Directory.Exists(_configurationDir))
            {
                Directory.CreateDirectory(_configurationDir);
            }
            _serverConfigurationPath = Path.Combine(_configurationDir, FILE_NAME);

        }

        public string UserRegisterApiEndpoint
        {
            get => _serverConfiguration.UserRegisterApiEndpoint;
            set => _serverConfiguration.UserRegisterApiEndpoint = value;
        }

        public string InquiryLogApiEndpoint
        {
            get => _serverConfiguration.InquiryLogApiEndpoint;
            set => _serverConfiguration.InquiryLogApiEndpoint = value;
        }

        public string[] Regions
        {
            get => _serverConfiguration.Regions.Split(",").Where(region => !string.IsNullOrEmpty(region)).ToArray();
            set => _serverConfiguration.Regions = string.Join(",", value);
        }

        public string DiagnosisKeyRegisterApiBaseEndpoint
        {
            get => _serverConfiguration.DiagnosisKeyRegisterApiBaseEndpoint;
            set => _serverConfiguration.DiagnosisKeyRegisterApiBaseEndpoint = value;
        }

        public string ExposureDataCollectServerBaseEndpoint
        {
            get => _serverConfiguration.ExposureDataCollectServerBaseEndpoint;
            set => _serverConfiguration.ExposureDataCollectServerBaseEndpoint = value;
        }


        public string DiagnosisKeyListProvideServerBaseEndpoint
        {
            get => _serverConfiguration.DiagnosisKeyListProvideServerBaseEndpoint;
            set => _serverConfiguration.DiagnosisKeyListProvideServerBaseEndpoint = value;
        }

        public async Task LoadAsync()
        {
            if (File.Exists(_serverConfigurationPath))
            {
                string config = await File.ReadAllTextAsync(_serverConfigurationPath);
                _serverConfiguration = JsonConvert.DeserializeObject<ServerConfiguration>(config);
                return;
            }

            _serverConfiguration = new ServerConfiguration();
            var configJson = JsonConvert.SerializeObject(_serverConfiguration, Formatting.Indented);
            await File.WriteAllTextAsync(_serverConfigurationPath, configJson);
        }

        public async Task SaveAsync()
        {
            var configJson = JsonConvert.SerializeObject(_serverConfiguration, Formatting.Indented);
            await File.WriteAllTextAsync(_serverConfigurationPath, configJson);
        }
    }

    public class ReleaseServerConfigurationRepository : IServerConfigurationRepository
    {
        public string UserRegisterApiEndpoint
        {
            get => Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, "register");
            set
            {
                // Do nothing
            }
        }

        public string InquiryLogApiEndpoint
        {
            get => Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, "inquirylog");
            set
            {
                // Do nothing
            }
        }

        public string[] Regions
        {
            get => AppSettings.Instance.SupportedRegions;
            set
            {
                //  Do nothing
            }
        }

        public string DiagnosisKeyRegisterApiBaseEndpoint
        {
            get => Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, AppSettings.Instance.DiagnosisApiVersion, "diagnosis");
            set
            {
                // Do nothing
            }
        }

        public string DiagnosisKeyListProvideServerBaseEndpoint
        {
            get => null;
            set
            {
                // Do nothing
            }
        }

        public string? ExposureDataCollectServerBaseEndpoint
        {
            get => null;
            set
            {
                // Do nothing
            }
        }

        public Task SaveAsync()
        {
            throw new NotSupportedException();
        }

        public Task LoadAsync()
        {
            throw new NotSupportedException();
        }

    }

    [JsonObject]
    public class ServerConfiguration
    {
        public const string PLACEHOLDER_REGION = "{region}";

        [JsonProperty("version")]
        public int Version = 1;

        [JsonProperty("user_register_api_endpoint")]
        public string UserRegisterApiEndpoint = Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, "register");

        [JsonProperty("inquiry_log_api_endpoint")]
        public string? InquiryLogApiEndpoint = Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, "inquirylog");

        [JsonProperty("regions")]
        public string Regions = string.Join(",", AppSettings.Instance.SupportedRegions);

        [JsonProperty("diagnosis_key_register_api_base_endpoint")]
        public string DiagnosisKeyRegisterApiBaseEndpoint
            = Utils.CombineAsUrl(AppSettings.Instance.ApiUrlBase, AppSettings.Instance.DiagnosisApiVersion, "diagnosis");

        [JsonProperty("diagnosis_key_list_provide_server_base_endpoint")]
        public string DiagnosisKeyListProvideServerBaseEndpoint
            = Utils.CombineAsUrl(
                AppSettings.Instance.CdnUrlBase,
                AppSettings.Instance.BlobStorageContainerName,
                PLACEHOLDER_REGION,
                "list.json"
                );

        [JsonProperty("exposure_data_collect_server_base_endpoint")]
        public string? ExposureDataCollectServerBaseEndpoint = null;
    }

}
